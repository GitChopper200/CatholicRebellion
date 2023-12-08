using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class ColiderLawSquare : MonoBehaviour
{
    [SerializeField]
    private Vector3 cube;
    //Makes own colider
    private void OnDrawGizmosSelected()
    {
        Color SquareColor = Color.red;
        SquareColor.a = 0.5f;
        Gizmos.color = SquareColor;
        Gizmos.DrawCube(transform.position, cube);
    }
    //Its scaning from itself, then it activates the triggers.
    public Collider[] GetCollisions() {
        return Physics.OverlapBox(transform.position, cube);

    }


}
