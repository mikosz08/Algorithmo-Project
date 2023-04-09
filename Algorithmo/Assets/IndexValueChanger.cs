using UnityEngine;

public class IndexValueChanger : ConsoleButton, IArrowIndexChanger
{
    public void ChangeIndexValue(int value)
    {
        Debug.Log("Nom");
    }

    public override void FireButton()
    {
        Debug.Log(gameObject.name + "fired!");
    }

}
