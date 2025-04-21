using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotateSpeed = 45f; // 每秒旋转角度
    public float floatAmplitude = 0.25f; // 上下浮动的幅度
    public float floatFrequency = 1f;     // 上下浮动的频率
    private Vector3 startPos;
    
    private void Start()
    {
        startPos = transform.position;
    }
    
    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime,0f, 0f);
        
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 增加分数
            ScoreManager.Instance.AddScore(1);

            // 播放音效或特效（可选）
            
            // 销毁金币
            Destroy(gameObject);
        }
    }
}
