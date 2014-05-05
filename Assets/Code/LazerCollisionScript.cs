using UnityEngine;
using System.Collections;

namespace BGE
{
    public class LazerCollisionScript : MonoBehaviour
    {
        void OnCollisionEnter(Collision col) {
            SteeringManager.PrintMessage("collided with: " + col.gameObject.name);
        }
    }
}
