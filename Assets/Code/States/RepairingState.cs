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
                entity.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(-21000, 2000, -40000);
                entity.GetComponent<SteeringBehaviours>().maxSpeed = 1500;
                entity.GetComponent<SteeringBehaviours>().maxForce = 125;
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
            if (SteeringManager.Instance.target_destroyed)
            {
                entity.GetComponent<StateMachine>().SwicthState(new SeekingEnemyState(entity));
            }
        }

        public override void Exit()
        {
            entity.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = false;
            entity.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = false;
            entity.GetComponent<SteeringBehaviours>().SeparationEnabled = false;
            entity.GetComponent<SteeringBehaviours>().PlaneAvoidanceEnabled = false;
        }
    }
}
