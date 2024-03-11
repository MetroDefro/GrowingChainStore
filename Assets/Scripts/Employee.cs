using System;
using System.Collections;
using UnityEngine;

// 알바생 능력치
public class EmployeeStatus
{
    public int Counter { get; set; }
    public int Make { get; set; }
    public int Clean { get; set; }
}

// 알바생의 정보들
public class EmployeeModel
{
    public string Name { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; } = new EmployeeStatus();
    // 월화수목금토일 오픈팀 오후팀 마감팀
    public (bool open, bool afternoon, bool close)[] IsWorkTime { get; set; } = new (bool open, bool afternoon, bool close)[7];
}

public class Employee : MonoBehaviour
{
    // 정보들은 나중에 세이브 파일에서 가져오기 용이하도록 분리해 두었다.
    private EmployeeModel model = new EmployeeModel();

    // 일하고 있나요?
    public bool IsWorking { get => isWorking; }
    private bool isWorking;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        // test
        model.EmployeeStatus.Counter = 5;
        model.EmployeeStatus.Make = 5;
        model.EmployeeStatus.Clean = 5;

        for (int i = 0; i < model.IsWorkTime.Length; i++)
        {
            model.IsWorkTime[i].open = true;
            model.IsWorkTime[i].afternoon = true;
            model.IsWorkTime[i].close = true;
        }
    }

    public void StartWorkingCounter(Action onEndWorking)
    {
        Debug.Log("오더 시작");
        StartCoroutine(Working(onEndWorking, 10 / model.EmployeeStatus.Counter));
    }

    public void StartWorkingMake(int makingTime, Action onEndWorking)
    {
        Debug.Log("제조 시작");
        StartCoroutine(Working(onEndWorking, makingTime * 10 / model.EmployeeStatus.Make));
    }

    public void StartWorkingClean(Action onEndWorking)
    {
        StartCoroutine(Working(onEndWorking, 10 / model.EmployeeStatus.Clean));
    }

    // 일 시키는 코루틴.
    // 속도는 능력치에 비례한다.
    // 처리가 끝나면 콜백함수 실행
    private IEnumerator Working(Action onEndWorking, float duringTime)
    {
        isWorking = true;
        yield return new WaitForSeconds(duringTime);
        isWorking = false;

        onEndWorking.Invoke();
    }
}
