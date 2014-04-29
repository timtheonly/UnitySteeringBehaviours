using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.States
{
    class HiddenState : InvisibleState
    {
        public HiddenState(GameObject entity) : base(entity) { }
        List<Color> origionalColors = new List<Color>();

        public override string Description()
        {
            return "Hidden State";
        }

        public override void Update()
        {
            if (SteeringManager.Instance.wraithEntry)
            {
                entity.GetComponent<StateMachine>().SwicthState(new RepairingState(entity));
            }
        }

    }
}