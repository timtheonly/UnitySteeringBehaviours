using System;
using System.Collections.Generic;
using UnityEngine;


namespace BGE.States
{
    public class IdleState:State
    {
        GameObject target;
        float range;

        public override string Description()
        {
            return "Idle State";
        }

        public IdleState(GameObject entity):base(entity)
        {
        }

        public override void Enter()
        {
            target = GameObject.FindGameObjectWithTag("target");
            range = 27000.0f;
        }
        public override void Exit()
        {
           
        }

        public override void Update()
        {
            SteeringManager.PrintFloat("Distance ",(target.transform.position - entity.transform.position).magnitude);
            SteeringManager.PrintFloat("Range ", range);
            //when target is in range start powering up
            if ((target.transform.position - entity.transform.position).magnitude < range)
            {
                
                entity.GetComponent<StateMachine>().SwicthState(new ChargingState(entity));
            }
        }
    }
}
