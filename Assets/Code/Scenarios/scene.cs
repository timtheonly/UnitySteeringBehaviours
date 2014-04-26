﻿using System;
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
            puddle_jumper.AddComponent<StateMachine>().SwicthState(new Fleeing(puddle_jumper));

            /*
             * wraith leader starts off hidden
             */
            wraith_leader = CreateBoid(new Vector3(-10000, 2500, -10), wraith_leader);
            wraith_leader.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            wraith_leader.AddComponent<StateMachine>().SwicthState(new Hidden(wraith_leader));
            /*
             * Set up camera
             */
            m_camera = Camera.main;
            m_camera.transform.position = new Vector3(550,600,550);
            GameObject satellite = GameObject.FindGameObjectWithTag("satellite");
            m_camera.transform.LookAt(satellite.transform);
        }
	}
}
