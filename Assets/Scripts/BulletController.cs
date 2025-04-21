using StarterAssets;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 7f;
    public float lifetime = 3f;

    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController player = other.GetComponent<ThirdPersonController>();
            if (player != null)
            {
                player.ReturnToRespawnPoint();
            }
            
            TrapFeedbackManager.Instance?.ShowWarning("Failed, Please Try Again");
            ScreenShake.Instance?.Shake();

            // 销毁球体
            Destroy(gameObject);
        }
        
    }
}