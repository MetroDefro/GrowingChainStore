using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// 배치된 알바생들을 가지고 있는 클래스
// 카운터, 제조, 청소 세 가지 일거리가 있다.
public class placedEmployees
{
    public List<Employee> Counter { get; set; } = new List<Employee>();
    public List<Employee> Make { get; set; } = new List<Employee>();
    public List<Employee> Clean { get; set; } = new List<Employee>();
}

public class Store : MonoBehaviour
{
    // 인기도. 테스트를 위해 50으로 고정했다. 즉 반반의 확률로 손님이 온다.
    private int popularity = 50;

    // 주문 큐, 제조 큐. 밀린 주문, 제조를 나타낸다. 현재 진행중인 주문, 제조는 포함하지 않는다!
    private Queue<(int makingtime, int price)> orderQueue = new Queue<(int makingtime, int price)>();
    private Queue<(int makingtime, int price)> makingQueue = new Queue<(int makingtime, int price)>();
    // 점포에 소속된 모든 알바생 리스트이나 지금은 강제로 시작하자마자 배치하였기 때문에 사용하지 않았다.
    private List<Employee> employeesList = new List<Employee>();
    // 배치된 알바생들을 가지고 있음
    private placedEmployees placedEmployeeList = new placedEmployees();
    // 번 돈
    private int Money = 0;

    // 초기화 함수. 테스트 용으로 매개변수로 알바생들을 받고 있으나 없앨 예정.
    public void Initialize(Employee employee1, Employee employee2, Employee employee3)
    {
        placedEmployeeList.Counter.Add(employee1);
        placedEmployeeList.Make.Add(employee2);
        placedEmployeeList.Clean.Add(employee3);

        // Queue를 구독하는 코루틴 실행
        StartCoroutine(SubscribeOrderQueue());
        StartCoroutine(SubscribeMakingQueue());
    }

    // 현재 1초에 한 번 실행되고 있다.
    public void Order()
    {
        // 인기도에 따라 확률적으로 손님이 온다.
        if (popularity >= Random.Range(0, 100))
        {
            // test 나중에는 상품 목록 만들어 랜덤으로, 주문에 걸리는 시간도 랜덤으로 주면 좋을 듯
            orderQueue.Enqueue((3, 1000));
            // 주문 큐에 변동이 생겼기 때문에 UI 반영
            GameManager.instance.StoreUIPresenter.SetOrderCountUI(orderQueue.Count);
        }
    }

    // 판매 완료되면 호출. 번 돈을 반영 함
    private void Sale(int price)
    {
        Money += price;
        GameManager.instance.StoreUIPresenter.SetMoneyUI(Money);
    }

    // 주문 큐를 구독.
    // 대기가 하나라도 있고, 일 하지 않는 주문 담당 알바생이 있을 경우 일을 시킨다.
    private IEnumerator SubscribeOrderQueue()
    {
        while (true) 
        {
            if (orderQueue.Count > 0)
            {
                for(int i = 0; i < placedEmployeeList.Counter.Count; i++)
                {
                    if (!placedEmployeeList.Counter[i].IsWorking)
                    {
                        (int makingTime, int price) = orderQueue.Dequeue();
                        GameManager.instance.StoreUIPresenter.SetOrderCountUI(orderQueue.Count);
                        placedEmployeeList.Counter[i].StartWorkingCounter(() => 
                        {
                            makingQueue.Enqueue((makingTime, price));
                            GameManager.instance.StoreUIPresenter.SetMakingCountUI(makingQueue.Count);
                        });
                    }
                }
            }
            yield return null;
        }
    }

    // 제조 큐를 구독.
    // 대기가 하나라도 있고, 일 하지 않는 제조 담당 알바생이 있을 경우 일을 시킨다.
    private IEnumerator SubscribeMakingQueue()
    {
        while (true)
        {
            if (makingQueue.Count > 0)
            {
                for (int i = 0; i < placedEmployeeList.Make.Count; i++)
                {
                    if (!placedEmployeeList.Make[i].IsWorking)
                    {
                        (int makingTime, int price) = makingQueue.Dequeue();
                        GameManager.instance.StoreUIPresenter.SetMakingCountUI(makingQueue.Count);
                        placedEmployeeList.Make[i].StartWorkingMake(makingTime, () =>
                        {
                            Sale(price);
                        });
                    }
                }
            }
            yield return null;
        }
    }
}