using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float maxRayDistance = 100.0f;
    private RaycastHit rayHit;

    private BinarySearchButtons previousButtonsBehaviour = null;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
        Debug.DrawRay(ray.origin, ray.direction * maxRayDistance, Color.green);

        if (Physics.Raycast(ray, out rayHit, maxRayDistance))
        {
            var buttonsBehaviour = rayHit.collider.gameObject.GetComponent<BinarySearchButtons>();
            if (rayHit.collider.CompareTag("ButtonObject"))
            {
                buttonsBehaviour.SwitchActive(true);
                previousButtonsBehaviour = buttonsBehaviour;
            }
            else if (previousButtonsBehaviour != null)
            {
                previousButtonsBehaviour.SwitchActive(false);
                previousButtonsBehaviour = null;
            }
        }

    }

}
