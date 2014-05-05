using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class BrokenState : State
    {
         public override string Description()
        {
            return "Broken State";
        }

        public BrokenState(GameObject entity):base(entity)
        {
        }

        public override void Enter()
        {
            entity.GetComponentInChildren<Light>().enabled = false;
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
