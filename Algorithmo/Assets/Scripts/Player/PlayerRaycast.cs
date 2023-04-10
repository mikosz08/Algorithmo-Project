using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] [Range(100.0f, 1000.0f)] private float maxRayDistance = 100.0f;

    private RaycastHit rayHit;
    private ConsoleButton seenConsoleButton = null;

    private void Update()
    {
        SendRay();
    }

    private void SendRay()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
        Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out rayHit, maxRayDistance))
        {
            if (rayHit.collider.CompareTag("ConsoleButton"))
            {
                var consoleButton = rayHit.collider.GetComponent<ConsoleButton>();

                if (seenConsoleButton != null && consoleButton != seenConsoleButton)
                {
                    seenConsoleButton.ShowCanvasText(false);
                }

                seenConsoleButton = consoleButton;
                seenConsoleButton.ShowCanvasText(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    seenConsoleButton.FireButton();
                }
            }
            else if (seenConsoleButton != null)
            {
                seenConsoleButton.ShowCanvasText(false);
                seenConsoleButton = null;
            }
        }
    }

    private void DrawRay()
    {

    }

}
