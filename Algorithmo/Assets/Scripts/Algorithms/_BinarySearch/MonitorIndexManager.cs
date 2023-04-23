
using TMPro;
using UnityEngine;


public class MonitorIndexManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI indexTextMesh = null;

    public bool IsReady { get; set; } = false;

    private int maxIndexValue = 100;
    public int MaxIndexValue { get { return maxIndexValue; } set { maxIndexValue = value; } }

    private int monitorIndexValue = 0;
    public int MonitorIndexValue
    {
        get
        {
            return monitorIndexValue;
        }
        set
        {
            monitorIndexValue = value < 0 ? 0 : value > maxIndexValue ? maxIndexValue : value;
            SetIndexText(monitorIndexValue.ToString());
            //binaryBoardManager.MarkObject(MonitorIndexValue);
        }
    }

    public void TurnOn(int indexMaxValue)
    {
        IsReady = true;
        MaxIndexValue = indexMaxValue;
    }

    public void AddToIndex(int value)
    {
        if (IsReady)
        {
            MonitorIndexValue += value;
        }
    }

    private void SetIndexText(string text)
    {
        if (IsReady)
        {
            indexTextMesh.text = text;
        }
    }

}
