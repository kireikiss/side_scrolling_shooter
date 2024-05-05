using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_EnemyProjectile : Projectile
{
    //variables que permiten referenciar al jugador, establecer la direccion, el componente rigid body y la velocidad del proyectil
    private GameObject player;

    private Vector3 direction;

    private Rigidbody rb;

    public float enemyProjectileSpeed;

    void Start()
    {
        //acá verifica si el jugador existe
        if (Controller_Player._Player != null)
        {
            // se obtiene la referencia a su objeto 
            player = Controller_Player._Player.gameObject;
            //se guarda en una variable dirección lo que seria la diferencia entre donde se encuentra el proyectil y el jugador. 
            //al ser  negativo se obtiene un vector que apunta desde el jugador al proyectil
            direction = -(this.transform.localPosition - player.transform.localPosition).normalized;
        }
        //se obtiene el rb del proyectil para acceder al componente que controla las fisicas
        rb = GetComponent<Rigidbody>();
    }

    
    public override void Update()
    {
        //se aplica una fuerza al rb multiplicando la direccion con la velocidad del proyectil
        rb.AddForce(direction*enemyProjectileSpeed);
        //se llama al update base, que chequea los limites
        base.Update();
    }
}
