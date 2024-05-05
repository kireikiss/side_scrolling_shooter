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
            //para q se mueva a la izq
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.deltaTime);
            rb.MovePosition(newPosition);

           
        }
    }

    IEnumerator TeleportRoutine()
    {
        while (true)
        {
           //espera un tiempo antes de tepearse
            yield return new WaitForSeconds(teleportDelay);
            Teleport();
        }
    }

    void Teleport()
    {
       
        isTeleporting = true;

        // se tepea a una posicion aleatoria entre los límites q establecí
        float randomY = Random.Range(teleportymin, teleportymax);
        Vector3 newPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        rb.MovePosition(newPosition);

        
        targetPosition = transform.position + Vector3.left * enemySpeed;

        
        StartCoroutine(ResetTeleportFlag());
    }

    IEnumerator ResetTeleportFlag()
    {
        
        yield return new WaitForSeconds(0.1f);
        isTeleporting = false;
    }
}
