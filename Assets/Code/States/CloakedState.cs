using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class CloakedState :InvisibleState
    {
        public CloakedState(GameObject entity) : base(entity) { }
        List<Color> origionalColors = new List<Color>();

        public override string Description()
        {
            return "Cloaked State";
        }

        public override void Update()
        {
            if (SteeringManager.Instance.ending)
            {
                entity.GetComponent<StateMachine>().SwicthState(new FleeingState(entity, new Vector3(1000,250,100)));
            }
        }
    }
}
