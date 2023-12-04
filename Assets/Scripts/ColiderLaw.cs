using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class ColiderLaw : MonoBehaviour
{
    [SerializeField]
    private float collisionRadius = 3.0f;
    //Makes own colider
    private void OnDrawGizmosSelected()
    {
        Color sphereColor = Color.red;
        sphereColor.a = 0.5f;
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position, collisionRadius);
    }
    //Its scaning from itself, then it activates the triggers.
    public Collider[] GetCollisions() {
        return Physics.OverlapSphere(transform.position, collisionRadius);

    }


}
