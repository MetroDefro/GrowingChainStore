using System;
using System.Collections;
using UnityEngine;

// �˹ٻ� �ɷ�ġ
public class EmployeeStatus
{
    public int Counter { get; set; }
    public int Make { get; set; }
    public int Clean { get; set; }
}

// �˹ٻ��� ������
public class EmployeeModel
{
    public string Name { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; } = new EmployeeStatus();
    // ��ȭ��������� ������ ������ ������
    public (bool open, bool afternoon, bool close)[] IsWorkTime { get; set; } = new (bool open, bool afternoon, bool close)[7];
}

public class Employee : MonoBehaviour
{
    // �������� ���߿� ���̺� ���Ͽ��� �������� �����ϵ��� �и��� �ξ���.
    private EmployeeModel model = new EmployeeModel();

    // ���ϰ� �ֳ���?
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
        Debug.Log("���� ����");
        StartCoroutine(Working(onEndWorking, 10 / model.EmployeeStatus.Counter));
    }

    public void StartWorkingMake(int makingTime, Action onEndWorking)
    {
        Debug.Log("���� ����");
        StartCoroutine(Working(onEndWorking, makingTime * 10 / model.EmployeeStatus.Make));
    }

    public void StartWorkingClean(Action onEndWorking)
    {
        StartCoroutine(Working(onEndWorking, 10 / model.EmployeeStatus.Clean));
    }

    // �� ��Ű�� �ڷ�ƾ.
    // �ӵ��� �ɷ�ġ�� ����Ѵ�.
    // ó���� ������ �ݹ��Լ� ����
    private IEnumerator Working(Action onEndWorking, float duringTime)
    {
        isWorking = true;
        yield return new WaitForSeconds(duringTime);
        isWorking = false;

        onEndWorking.Invoke();
    }
}
