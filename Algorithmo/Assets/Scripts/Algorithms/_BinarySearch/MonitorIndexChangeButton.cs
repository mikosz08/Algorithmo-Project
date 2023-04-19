using UnityEngine;

public class MonitorIndexChangeButton : ConsoleButton
{
    [SerializeField] private int indexChange = 0;
    //[SerializeField] private BinaryBoardManager binaryBoardManager = null;

    private MonitorIndexManager monitorIndexManager = null;

    private void Start()
    {
        monitorIndexManager = GetComponentInParent<MonitorIndexManager>();
    }

    public override void FireButton()
    {
        monitorIndexManager.AddToIndex(indexChange);
        //binaryBoardManager.MarkObject(monitorIndexManager.IndexValue);
    }
}
