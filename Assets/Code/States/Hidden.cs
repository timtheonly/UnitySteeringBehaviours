using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class Hidden : State
    {
        public Hidden(GameObject entity) : base(entity) { }
        List<Color> origionalColors = new List<Color>();

        public override string Description()
        {
            return "hidden";
        }

        public override void Enter()
        {

            Renderer[] renderers = entity.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                origionalColors.Add(renderers[i].material.color);
                renderers[i].material.color = Color.clear;
                Debug.Log(renderers[i].material.name);
            }
        }

        public override void Update()
        {
            if (SteeringManager.Instance.wraithEntry)
            {
                entity.GetComponent<StateMachine>().SwicthState(new Repairing(entity));
            }
        }

        public override void Exit()
        {
            Renderer[] renderers = entity.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = origionalColors[i];
            }
        }
    }
}