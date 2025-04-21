using StarterAssets;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public float pulseSpeed = 2f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        transform.localScale = originalScale * scale;
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
        }
    }
    
}