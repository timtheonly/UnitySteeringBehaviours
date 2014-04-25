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
        Camera m_camera;

        public override string Description()
        {
            return "Sci-fi scene";
        }

        public override void Start()
        {
            /*
             * Puddle jumper starts fleeing 
             */
            puddle_jumper = CreateBoid(new Vector3(-49.858f, -158.44f, 163.976f), leaderPrefab);
            puddle_jumper.transform.localScale = new Vector3(8.5f, 8.5f, 8.5f);
            puddle_jumper.AddComponent<StateMachine>().SwicthState(new Fleeing(puddle_jumper));

            /*
             * Set up camera
             */
            m_camera = Camera.main;
            m_camera.transform.position = new Vector3(1200,1100,900);
        }
	}
}
