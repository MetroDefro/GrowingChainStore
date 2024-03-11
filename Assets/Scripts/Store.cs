using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// ��ġ�� �˹ٻ����� ������ �ִ� Ŭ����
// ī����, ����, û�� �� ���� �ϰŸ��� �ִ�.
public class placedEmployees
{
    public List<Employee> Counter { get; set; } = new List<Employee>();
    public List<Employee> Make { get; set; } = new List<Employee>();
    public List<Employee> Clean { get; set; } = new List<Employee>();
}

public class Store : MonoBehaviour
{
    // �α⵵. �׽�Ʈ�� ���� 50���� �����ߴ�. �� �ݹ��� Ȯ���� �մ��� �´�.
    private int popularity = 50;

    // �ֹ� ť, ���� ť. �и� �ֹ�, ������ ��Ÿ����. ���� �������� �ֹ�, ������ �������� �ʴ´�!
    private Queue<(int makingtime, int price)> orderQueue = new Queue<(int makingtime, int price)>();
    private Queue<(int makingtime, int price)> makingQueue = new Queue<(int makingtime, int price)>();
    // ������ �Ҽӵ� ��� �˹ٻ� ����Ʈ�̳� ������ ������ �������ڸ��� ��ġ�Ͽ��� ������ ������� �ʾҴ�.
    private List<Employee> employeesList = new List<Employee>();
    // ��ġ�� �˹ٻ����� ������ ����
    private placedEmployees placedEmployeeList = new placedEmployees();
    // �� ��
    private int Money = 0;

    // �ʱ�ȭ �Լ�. �׽�Ʈ ������ �Ű������� �˹ٻ����� �ް� ������ ���� ����.
    public void Initialize(Employee employee1, Employee employee2, Employee employee3)
    {
        placedEmployeeList.Counter.Add(employee1);
        placedEmployeeList.Make.Add(employee2);
        placedEmployeeList.Clean.Add(employee3);

        // Queue�� �����ϴ� �ڷ�ƾ ����
        StartCoroutine(SubscribeOrderQueue());
        StartCoroutine(SubscribeMakingQueue());
    }

    // ���� 1�ʿ� �� �� ����ǰ� �ִ�.
    public void Order()
    {
        // �α⵵�� ���� Ȯ�������� �մ��� �´�.
        if (popularity >= Random.Range(0, 100))
        {
            // test ���߿��� ��ǰ ��� ����� ��������, �ֹ��� �ɸ��� �ð��� �������� �ָ� ���� ��
            orderQueue.Enqueue((3, 1000));
            // �ֹ� ť�� ������ ����� ������ UI �ݿ�
            GameManager.instance.StoreUIPresenter.SetOrderCountUI(orderQueue.Count);
        }
    }

    // �Ǹ� �Ϸ�Ǹ� ȣ��. �� ���� �ݿ� ��
    private void Sale(int price)
    {
        Money += price;
        GameManager.instance.StoreUIPresenter.SetMoneyUI(Money);
    }

    // �ֹ� ť�� ����.
    // ��Ⱑ �ϳ��� �ְ�, �� ���� �ʴ� �ֹ� ��� �˹ٻ��� ���� ��� ���� ��Ų��.
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

    // ���� ť�� ����.
    // ��Ⱑ �ϳ��� �ְ�, �� ���� �ʴ� ���� ��� �˹ٻ��� ���� ��� ���� ��Ų��.
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