using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;

        public CharacterAnimation(PlayerController entity)
        {
            _animator = entity.GetComponentInChildren<Animator>();
        }

        public void MoveAnimations()
        {

        }
    }
}

