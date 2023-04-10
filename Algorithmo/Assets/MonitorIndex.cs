using TMPro;
using UnityEngine;


public class MonitorIndex : MonoBehaviour
{

    [SerializeField] private int indexValue = 0;
    [SerializeField] private int maxIndexValue = 100;
    [SerializeField] private TextMeshProUGUI indexTextMesh = null;

    public int IndexValue
    {
        get
        {
            return indexValue;
        }
        set
        {
            // ? :D
            indexValue = value < 0 ? 0 : value > maxIndexValue ? maxIndexValue : value;
        }
    }

    private void Start()
    {
        indexTextMesh.text = indexValue.ToString();
    }

    public void UpdateMonitorIndexText(int value)
    {

        IndexValue += value;
        indexTextMesh.text = IndexValue.ToString();
    }

}
