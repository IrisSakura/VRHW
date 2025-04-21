using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public Vector3 moveDirection =new Vector3(1,0,0); // 移动方向（默认左右）
    public float moveDistance = 3f;               // 移动范围
    public float moveSpeed = 2f;                  // 移动速度

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        Vector3 newPosition = startPos + moveDirection.normalized * offset;
        transform.position = newPosition;
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
