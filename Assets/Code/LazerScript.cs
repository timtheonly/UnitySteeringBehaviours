using UnityEngine;
using System.Collections;

namespace BGE
{
    public class LazerScript : MonoBehaviour
    {

        LineRenderer line;
        GameObject target;

        public bool rayCastEnabled;

        //don't want the wraith ship to be destroyed imediatly
        float time_elapsed;
        float time_wait =0.5f;

        // Use this for initialization
        void Start()
        {
            line = gameObject.GetComponent<LineRenderer>();
            line.enabled = true;
            rayCastEnabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            target = GameObject.FindGameObjectWithTag("target");

            if (rayCastEnabled)
            {
                line.enabled = true;
                //need to find direction to rotate
                Vector3 direction = (target.transform.position + new Vector3(0, 1600, 0)) - transform.position;//add offset to targets position as y value is not always true
                transform.rotation = Quaternion.LookRotation(direction);

                Ray ray = new Ray(transform.position, transform.forward);

                line.SetPosition(0, ray.origin);
                line.SetPosition(1, ray.GetPoint(20000));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 20000))
                {
                    if (hit.transform.gameObject.CompareTag("target"))
                    {
                        if (time_elapsed > time_wait)
                        {
                            SteeringManager.Instance.target_destroyed = true;
                            Destroy(hit.transform.gameObject);
                        }
                        time_elapsed += Time.deltaTime;
                    }
                }
            }
            else 
            {
                line.enabled = false;
            }
        }
    }
}