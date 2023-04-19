
using TMPro;
using UnityEngine;


public class MonitorIndexManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI indexTextMesh = null;
    [SerializeField] private BinaryBoardManager binaryBoardManager = null;

    public bool IsReady { get; set; } = false;

    private int maxIndexValue = 100;
    public int MaxIndexValue { get { return maxIndexValue; } set { maxIndexValue = value; } }

    private int indexValue = 0;
    public int IndexValue
    {
        get
        {
            return indexValue;
        }
        set
        {
            indexValue = value < 0 ? 0 : value > maxIndexValue ? maxIndexValue : value;
            SetIndexText(indexValue.ToString());
            binaryBoardManager.MarkObject(IndexValue);
        }
    }

    public void AddToIndex(int value)
    {
        if (!IsReady)
        {
            return;
        }
        IndexValue += value;
    }

    private void SetIndexText(string text)
    {
        if (!IsReady)
        {
            return;
        }
        indexTextMesh.text = text;
    }

}
