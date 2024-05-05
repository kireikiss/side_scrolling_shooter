using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //variables para especificar los límites en los ejes X Y
    public float xLimit = 30;
    public float yLimit = 20;
    
    virtual public void Update()
    {
        //acá se llama al metodo que verifica si el proyectil se pasó de los límites
        CheckLimits();
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        //si el proyectil colisiona con una pared o el piso automaticametne se destruye
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void CheckLimits()
    {
        /*acá se especifica cuando se destruye el proyectil después de traspasar ciertas coordenadas,
        utilizando las variables del inicio como referencia.*/
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.y < -yLimit)
        {
            Destroy(this.gameObject);
        }

    }

}
