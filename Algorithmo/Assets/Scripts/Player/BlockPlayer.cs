using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            
        }
    }
}
