using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_RandomEnemy : Controller_Enemy
{
   
    public float teleportymax = 20f;
    public float teleportymin = -2f;
    public float teleportDelay = 1f;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool isTeleporting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position + Vector3.left * enemySpeed;
        StartCoroutine(TeleportRoutine());
    }

    public override void Update()
    {
        if (!isTeleporting)
        {
            // Move towards the left
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
            rb.MovePosition(newPosition);

           
        }
    }

    IEnumerator TeleportRoutine()
    {
        while (true)
        {
            // Teleport after a delay
            yield return new WaitForSeconds(teleportDelay);
            Teleport();
        }
    }

    void Teleport()
    {
        // Set teleporting flag to prevent movement during teleportation
        isTeleporting = true;

        // Teleport to a random Y position
        float randomY = Random.Range(teleportymin, teleportymax);
        Vector3 newPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        rb.MovePosition(newPosition);

        // Reset target position for movement
        targetPosition = transform.position + Vector3.left * enemySpeed;

        // Reset teleporting flag after a delay
        StartCoroutine(ResetTeleportFlag());
    }

    IEnumerator ResetTeleportFlag()
    {
        // Wait for a short duration before resetting teleporting flag
        yield return new WaitForSeconds(0.1f);
        isTeleporting = false;
    }
}
