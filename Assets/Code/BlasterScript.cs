using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {

    public bool blaster_enabled;
    GameObject target;
    float shot_fired, shot_limit;

	// Use this for initialization
	void Start () {
        blaster_enabled = false;
        target = GameObject.FindGameObjectWithTag("satellite");
        shot_fired = 0.25f;
        shot_limit = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(blaster_enabled)
        {
            if (shot_fired > shot_limit)
            {
                GameObject blast = Instantiate(Resources.Load("wraith_lazer_blast")) as GameObject;
                blast.transform.position = transform.position;

                Vector3 direction = (target.transform.position + new Vector3(0, 10, -50)) - transform.position;//add offset to targets position as y value is not always true
                blast.transform.rotation = Quaternion.LookRotation(direction);

                shot_fired = 0.0f;
            }
            shot_fired += Time.deltaTime;
        }
	}
}
