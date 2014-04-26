using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class Repairing : State
    {
        public Repairing(GameObject entity): base(entity){}

        public override string Description()
        {
            return "rapairing";
        }

        public override void Enter()
        {
            entity.GetComponent<SteeringBehaviours>().SeekEnabled = true;
            entity.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(5000,-5000,-2500);
            entity.GetComponent<SteeringBehaviours>().maxSpeed = 1000;
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
