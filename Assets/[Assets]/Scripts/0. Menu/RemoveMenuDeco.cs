using UnityEngine;

public class RemoveMenuDeco : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("DecoRemover"))
        {
            Destroy(gameObject);
        }
    }
}
