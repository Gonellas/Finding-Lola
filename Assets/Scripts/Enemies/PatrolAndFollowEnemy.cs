using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndFollowEnemy : MonoBehaviour
{
    public Transform target; //busca al player
    public int speed;
    bool playerSpotted;

    public Transform[] waypointsArray; //array para el movimiento de patrulla del enemigo dinámico
    public List<Transform> waypointsList; //lista para el movimiento de patrulla del enemigo dinámico

    int waypointIndex = 0; //asignamos la posición en la lista/array de los waypoints. Movimiento circular.

    int directionWaypoint = 1;  //movimiento para atrás y adelante del enemigo. Se cambia el valor de 1 a -1

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        if (playerSpotted) followPlayerRotationSpottedPoint();
        else Patrol();
    }

    void Patrol()
    {
        //ARRAY
        if(waypointsArray.Length <=0) return; //El length cuenta la cantidad de elementos en el array, si es menor o igual a cero, retorna.
        //if(waypointsList.Count <=0) return; //Lo mismo pero en Lista.

        transform.position = Vector3.MoveTowards(transform.position, waypointsArray[waypointIndex].position, speed * Time.deltaTime); 
        //Agarra el Vector 3 de la posicion actual, lo compara con el vector 3 de la posicion deseada y agarra la velocidad con la que se va a mover el objeto.
        if(Vector3.Distance(transform.position, waypointsArray[waypointIndex].position) < 0.5f) //recomienda que sea de 0.5 a 1 sino el personaje se queda girando en el waypoint
        {
            waypointIndex++;

            if (waypointIndex >=waypointsArray.Length) 
            {
                waypointIndex = 0;
            }
        }

        //LISTA
        /*if (waypointsList.Count <= 0) return;

        transform.position = Vector3.MoveTowards(transform.position, waypointsList[waypointIndex].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypointsList[waypointIndex].position) < 0.5f) 
        {
            waypointIndex++;

            if (waypointIndex >= waypointsList.Count)
            {
                waypointIndex = 0;
            }
        }*/

    }

    void followPlayerRotationSpottedPoint() //El enemigo rota al descubrir al personaje
    {
        Vector3 direction = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction); //(Vector2.right o left según como está la imágen)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void PlayerHasBeenSeen()
    {
        if (!playerSpotted) playerSpotted = true;
        else playerSpotted = false;
    }
}
