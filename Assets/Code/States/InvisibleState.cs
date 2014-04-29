using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/*
 * parent state for both
 * hidden and cloaked states
 * both have a form of invisibility 
 * but different updates
 */
namespace BGE.States
{
	public abstract class  InvisibleState : State
	{
        List<Color> origionalColors = new List<Color>();

        public InvisibleState(GameObject entity) : base(entity) { }

        public override void Enter()
        {
            Renderer[] renderers = entity.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                origionalColors.Add(renderers[i].material.color);
                renderers[i].material.color = Color.clear;
            }
        }

        public override void Exit()
        {
            Renderer[] renderers = entity.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = origionalColors[i];
            }
        }
        
	}
}
