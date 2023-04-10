using UnityEngine;

public class IndexValueChanger : ConsoleButton
{

    [SerializeField] private int indexChange = 0;

    private MonitorIndex monitorIndex = null;

    private void Start()
    {
        monitorIndex = GetComponentInParent<MonitorIndex>();
    }

    public override void FireButton()
    {
        //Debug.Log(gameObject.name + "fired!");
        monitorIndex.UpdateMonitorIndexText(indexChange);
    }

    //private void ChangeIndexValue

}
