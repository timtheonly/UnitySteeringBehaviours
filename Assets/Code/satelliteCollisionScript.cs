using UnityEngine;
using System.Collections;
namespace BGE
{
    public class satelliteCollisionScript : MonoBehaviour
    {
        int hits;
        // Use this for initialization
        void Start()
        {
            hits = 0;
        }

        // Update is called once per frame
        void Update()
        {
           
            SteeringManager.PrintMessage("hits: " + hits);
        }

        void OnTrigger(Collision col)
        {
           Debug.Log("hits: " + hits);
            if (col.gameObject.CompareTag("blast"))
            {
                hits++;
                if (hits > 20)
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}