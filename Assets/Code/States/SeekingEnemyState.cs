using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class SeekingEnemyState : State
    {

        float range;
        GameObject satellite;

        public SeekingEnemyState(GameObject entity):base(entity){ }

        public override string Description()
        {
            return "Seeking enemy state";
        }

        public override void Enter()
        {
            range = 10000;
            satellite = GameObject.FindGameObjectWithTag("satellite");
            entity.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
            entity.GetComponent<SteeringBehaviours>().seekTargetPos = satellite.transform.position + new Vector3(0, 200, 0);
            entity.GetComponent<SteeringBehaviours>().maxSpeed = 1000;
            entity.GetComponent<SteeringBehaviours>().maxForce = 150;
        }

        public override void Update()
        {
            
            if ((satellite.transform.position - entity.transform.position).magnitude < range)
            {
                entity.GetComponent<StateMachine>().SwicthState(new wraith_attackingState(entity));
            }
        }

        public override void Exit()
        {
            
        }

    }
}
