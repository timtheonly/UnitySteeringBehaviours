using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;


namespace BGE.States
{
    class AttackingState:State
    {
        GameObject target;
        

        public override string Description()
        {
            return "Attacking State";
        }

        public AttackingState(GameObject entity):base(entity)
        {
        }

        public override void Enter()
        {
            entity.GetComponentInChildren<LazerScript>().rayCastEnabled = true;
        }

        public override void Exit()
        {
            entity.GetComponentInChildren<LazerScript>().rayCastEnabled = false;
        }

        public override void Update()
        {
            if (SteeringManager.Instance.target_destroyed)
            {
                
                entity.GetComponent<StateMachine>().SwicthState(new BrokenState(entity));
            }
        }

    }
}
