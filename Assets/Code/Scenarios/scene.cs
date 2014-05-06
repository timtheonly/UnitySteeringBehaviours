using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BGE.States;

namespace BGE.Scenarios
{
    class scene : Scenario
	{
        GameObject puddle_jumper;
        GameObject wraith_leader;
        GameObject fleet_member;
        Camera m_camera;

        public override string Description()
        {
            return "Sci-fi scene";
        }

        public override void Start()
        {
            /*
             * Puddle jumper starts with fleeing 
             */
            puddle_jumper = CreateBoid(new Vector3(-49.858f, -158.44f, 163.976f), PuddleJumperPrefab);
            puddle_jumper.transform.localScale = new Vector3(8.5f, 8.5f, 8.5f);
            puddle_jumper.AddComponent<StateMachine>().SwicthState(new FleeingState(puddle_jumper));

            /*
             * wraith leader starts off hidden
             */
            wraith_leader = CreateBoid(new Vector3(-20000, 2000, 20000), WraithleaderPrefab);
            wraith_leader.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            wraith_leader.tag = "wraith_leader";
            wraith_leader.AddComponent<StateMachine>().SwicthState(new HiddenState(wraith_leader));

            /*
            * set up wraith fleet
            */
            Vector3 offset = new Vector3(5000, 0, 1500);
            fleet_member = CreateBoid(wraith_leader.transform.position + offset, boidPrefab);
            fleet_member.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            fleet_member.GetComponent<SteeringBehaviours>().leader = wraith_leader;
            fleet_member.GetComponent<SteeringBehaviours>().offset = offset;
            fleet_member.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(0, 0, 10);
            fleet_member.GetComponent<SteeringBehaviours>().maxSpeed = 500;
            fleet_member.GetComponent<SteeringBehaviours>().maxForce = 150;
            fleet_member.AddComponent<StateMachine>().SwicthState(new HiddenState(fleet_member));

            offset = new Vector3(15000, 0, 4000);
            fleet_member = CreateBoid(wraith_leader.transform.position + offset, boidPrefab);
            fleet_member.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            fleet_member.GetComponent<SteeringBehaviours>().leader = wraith_leader;
            fleet_member.GetComponent<SteeringBehaviours>().offset = offset;
            fleet_member.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(250, 0, 250);
            fleet_member.GetComponent<SteeringBehaviours>().maxSpeed = 500;
            fleet_member.GetComponent<SteeringBehaviours>().maxForce = 150;
            fleet_member.AddComponent<StateMachine>().SwicthState(new HiddenState(fleet_member));


            //this is the target that the satellite will shoot down
            offset = new Vector3(7000,0,5500);
            fleet_member = CreateBoid(wraith_leader.transform.position + offset, WraithleaderPrefab);
            fleet_member.tag = "target";
            fleet_member.GetComponent<SteeringBehaviours>().leader = wraith_leader;
            fleet_member.GetComponent<SteeringBehaviours>().offset = offset;
            fleet_member.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(0, 0, 100);
            fleet_member.GetComponent<SteeringBehaviours>().maxSpeed = 750;
            fleet_member.GetComponent<SteeringBehaviours>().maxForce = 100;
            fleet_member.AddComponent<StateMachine>().SwicthState(new HiddenState(fleet_member));
            
            //get the satellite from the scene and add a state machine
            GameObject satellite = GameObject.FindGameObjectWithTag("satellite");
            satellite.AddComponent<StateMachine>().SwicthState(new IdleState(satellite));
            /*
             * Set up camera
             */
            m_camera = Camera.main;
            m_camera.transform.position = new Vector3(550,1000,550);
            
            m_camera.transform.LookAt(satellite.transform);
        }
	}
}
