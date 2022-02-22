using shootandRun1.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shootandRun1.Abstracts.Controllers;


namespace shootandRun1.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;

        public CharacterAnimation(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f, Time.deltaTime);
        }

        public void AttackAnimation(bool canAttack)
        {
            _animator.SetBool("isAttack", canAttack);
        }

        public void DeadAnimation()
        {
            _animator.SetTrigger("Death");
        }
    }
}

