using UnityEngine;
using System.Collections;

public class move_blaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * 1000 * Time.deltaTime;
	}
}
