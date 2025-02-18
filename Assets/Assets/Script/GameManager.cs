using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton pattern

    private Vector3 lastCheckpointPosition;
    private bool checkpointReached = false;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lastCheckpointPosition = player.transform.position; // Set the initial spawn point
    }

    private void Update()
    {
        // R to manually respawn
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }

        // Destroy player when timer reaches stopTime
        if (Timer.Instance != null && Timer.Instance.   elapsedTime >= Timer.Instance.stopTime)
        {
            Debug.Log("Time is up! Destroying player...");
            Destroy(player);
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
        checkpointReached = true;
        Debug.Log("Checkpoint saved at: " + lastCheckpointPosition);
    }

    public void Respawn()
    {
        if (checkpointReached)
        {
            Debug.Log("Respawning at: " + lastCheckpointPosition);
            player.transform.position = lastCheckpointPosition;
        }
        else
        {
            Debug.Log("No checkpoint reached yet!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Respawn();
        }
        if (other.CompareTag("FinishLine"))
        {
            Timer.Instance.StopTimer();
        }
    }
}