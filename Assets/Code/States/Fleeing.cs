using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
	class Fleeing : State
	{
        Vector3 target;
        public Fleeing(GameObject entity) : base(entity) {
            target = new Vector3(250, 500, -250);
        }

        public Fleeing(GameObject entity, Vector3 target): base(entity)
        {
            this.target = target;
        }

        public override string Description()
        {
            return "Fleeing State";
        }

        public override void Enter() {
            
            entity.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
            entity.GetComponent<SteeringBehaviours>().seekTargetPos = target;
            entity.GetComponent<SteeringBehaviours>().maxSpeed = 1000;
        }
        public override void Exit() { 
        
        }

        public override void Update() {
            Vector3 distance = entity.transform.position - target;
            if (distance.magnitude < 0.1f)
            {
                SteeringManager.Instance.wraithEntry = true;
                entity.GetComponent<SteeringBehaviours>().ArriveEnabled = false;
                entity.GetComponent<StateMachine>().SwicthState(new Cloaked(entity));
            }
        
        }
	}
}
