using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManager.Instance.Respawn();
        }
    }
}