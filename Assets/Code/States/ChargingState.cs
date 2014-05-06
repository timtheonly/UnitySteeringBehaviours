using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class ChargingState :State
    {
        float range;
        public override string Description()
        {
            return "Charging State";
        }

        public ChargingState(GameObject entity):base(entity){ }

        public override void Enter()
        {
            entity.GetComponentInChildren<Light>().intensity = 0.0f;
            entity.GetComponentInChildren<Light>().enabled = true;
            range = 25000;
        }
        public override void Exit()
        {
           
        }

        public override void Update()
        {
            
            GameObject target = GameObject.FindGameObjectWithTag("target");
            SteeringManager.PrintFloat("Distance ", (target.transform.position - entity.transform.position).magnitude);
            SteeringManager.PrintFloat("Range ", range);
            if (entity.GetComponentInChildren<Light>().intensity <= 8.0f)
            {
                entity.GetComponentInChildren<Light>().intensity += 0.01f;
            }
            //when target is in range start change to attacking state
            if ((target.transform.position - entity.transform.position).magnitude < range)
            {

                entity.GetComponent<StateMachine>().SwicthState(new AttackingState(entity));
            }
        }
    }
}
