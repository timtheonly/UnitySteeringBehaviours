using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class RepairingState : State
    {
        public RepairingState(GameObject entity): base(entity){}

        public override string Description()
        {
            return "Repairing State";
        }

        public override void Enter()
        {
            if (entity.CompareTag("wraith_leader"))
            {
                entity.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
                entity.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(-21000, 2500, -40000);
                entity.GetComponent<SteeringBehaviours>().maxSpeed = 1000;
                entity.GetComponent<SteeringBehaviours>().maxForce = 100;
            }
            else {
                entity.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
                entity.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = true;
                entity.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
                entity.GetComponent<SteeringBehaviours>().PlaneAvoidanceEnabled = true;
            }
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
