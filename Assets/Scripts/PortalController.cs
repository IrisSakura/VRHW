using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform teleportTarget;
    public bool useFadeEffect = false; // 可选淡入淡出

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other.gameObject));
        }
    }

    private IEnumerator TeleportPlayer(GameObject player)
    {
        canTeleport = false;

        if (useFadeEffect)
        {
            yield return new WaitForSeconds(0.1f);
        }

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = teleportTarget.position;

        if (cc != null) cc.enabled = true;

        if (useFadeEffect)
        {
            // 插入淡入动画
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f); // 冷却，防止立刻重复传送
        canTeleport = true;
    }
}