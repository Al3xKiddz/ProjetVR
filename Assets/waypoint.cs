using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [SerializeField]
    //rayon de la boule du waypoint pour le debug
    protected float rayondebug = 1.0F;
    //pour que la boule sois dessinee en meme temps
    //que les autres gizmos de la scene
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rayondebug);
    }
}
