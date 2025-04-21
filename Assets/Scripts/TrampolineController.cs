using StarterAssets;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    public float bounceVelocity = 20f; // 蹦床弹跳力度

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController player = other.GetComponent<ThirdPersonController>();
            if (player != null)
            {
                player.Bounce(bounceVelocity);
            }
        }
    }
}