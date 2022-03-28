using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position;
        }
    }

    public void SetPlayerToSpawn()
    {
        player.position = respawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
