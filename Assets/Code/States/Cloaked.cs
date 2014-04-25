using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class Cloaked :State
    {
        public Cloaked(GameObject entity) : base(entity) { }
        List<Color> origionalColors = new List<Color>();

        public override string Description()
        {
            return "cloaked";
        }

        public override void Enter(){

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
            if (SteeringManager.Instance.ending)
            {
                entity.GetComponent<StateMachine>().SwicthState(new Fleeing(entity, new Vector3(1000,250,100)));
            }
        }

        public override void Exit(){
            Renderer[] renderers = entity.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = origionalColors[i];
            }
        }
    }
}
