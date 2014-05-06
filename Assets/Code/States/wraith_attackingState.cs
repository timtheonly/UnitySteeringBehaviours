using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class wraith_attackingState:State
    {
        public wraith_attackingState(GameObject entity) : base(entity) { }

        public override string Description()
        {
            return "Wraith attacking state";
        }

        public override void Enter()
        {
            entity.GetComponent<SteeringBehaviours>().ArriveEnabled = false;
            foreach (BlasterScript blaster in entity.GetComponentsInChildren<BlasterScript>())
            { 
                    blaster.blaster_enabled = true;
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
