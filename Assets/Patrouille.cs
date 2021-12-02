using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrouille : MonoBehaviour
{
    //liste de waypoint
    [SerializeField]
    List<waypoint> waypointPat;

    //variables privee pour la classe
    NavMeshAgent navMeshAgent;
    int indexPatrouille;
    bool bouge;
    bool patrouilleAvant;

    //initialization
    public void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if(navMeshAgent == null)//pour etre sur que je cherche pas si joublie
        {
            Debug.Log("nav mesh pas attacher " + gameObject.name);
        }
        else
        {
            if(waypointPat != null && waypointPat.Count >= 2)//sinon je me met vulnerable a des erreurs
            {
                indexPatrouille = 0;
                setDestination();
            }
            else
            {
                Debug.Log("pas assez de points");
            }
        }
    }

    public void Update()
    {
        //si on est proche du waypoint
        if(bouge && navMeshAgent.remainingDistance <= 0.5f)
        {
            bouge = false;
            changeWaypoint();
            setDestination();
        }
    }

    private void setDestination()
    {
        if(waypointPat != null)//si ma liste est pas vide
        {
            Debug.Log("set la destination");
            Vector3 target = waypointPat[indexPatrouille].transform.position;//aller chercher le prochain waypoint
            navMeshAgent.SetDestination(target);//donner la destination
            bouge = true;
        }
    }

    private void changeWaypoint()//change le waypoint
    {
        //anciennement
        //incremente l'index et avec le modulo le remet a zero si
        //il est egal au nombre de waypoint dans la liste
        //indexPatrouille = (indexPatrouille++) % waypointPat.Count;

        //incremente l'index et si il arrice au boute de la liste revient a zero
        indexPatrouille++;
        if(indexPatrouille >= waypointPat.Count)
        {
            indexPatrouille = 0;
        }

        Debug.Log(indexPatrouille);
    }

}
