using UnityEngine;

public class TrapController : MonoBehaviour
{
    public GameObject ballPrefab;
    public float fireInterval = 2f;
    public float fireStartTime;
    public Vector3 shootDirection = Vector3.forward;

    private void Start()
    {
        InvokeRepeating(nameof(Fire), fireStartTime, fireInterval);
    }

    private void Fire()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        BulletController ballScript = ball.GetComponent<BulletController>();
        ballScript.SetDirection(shootDirection);
    }
}