using UnityEngine;

public class EmployeeStatus
{
    public int Counter { get; set; }
    public int Make { get; set; }
    public int Clean { get; set; }
}

public class EmployeePresenter : MonoBehaviour
{
    public EmployeeStatus EmployeeStatus { get; set; } = new EmployeeStatus();
    public (bool open, bool afternoon, bool close)[] IsWorkTime { get; set; } = new (bool open, bool afternoon, bool close)[7];

    private EmployeeView view;

    private void Awake()
    {
        view = GetComponent<EmployeeView>();
    }
}
