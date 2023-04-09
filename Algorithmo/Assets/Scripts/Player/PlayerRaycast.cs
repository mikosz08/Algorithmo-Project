using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float maxRayDistance = 100.0f;

    private RaycastHit rayHit;
    private ConsoleButton seenConsoleButton = null;

    private void Update()
    {
        Scan();
    }

    private void Scan()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
        Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out rayHit, maxRayDistance))
        {
            if (rayHit.collider.CompareTag("ConsoleButton"))
            {
                seenConsoleButton = rayHit.collider.GetComponent<ConsoleButton>();
                seenConsoleButton.ShowCanvasText(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    seenConsoleButton.FireButton();
                }
            }
            else if (seenConsoleButton != null)
            {
                seenConsoleButton.ShowCanvasText(false);
            }

        }
    }
}
