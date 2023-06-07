using Brad.Character;
using Brad.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawn : BaseState
{
    private NPC_Controller _cont;
    public S_Spawn(NPC_Controller stateMachine) : base("Spawn", stateMachine) 
    {
        _cont = stateMachine;
    }

    #region State methods
    public override void Enter()
    {
        base.Enter();
        _cont.EnableNPC(false);
        _cont.Set_AnimTrigger("tRespawn");
    }

    public override void UpdateState()
    {
        if (!_cont.Get_IsNpcOutOfRange())
        {
            _cont.EnableNPC(true);
            _cont.TryGetComponent<IDamagable>(out IDamagable _contDmg);
            if (_contDmg != null)
            {
                _contDmg.MaxHealth = _cont.maxHealth;
                _contDmg.Health = _cont.MaxHealth;
            }
            _cont.ChangeState(_cont.idleState);
        }
    }

    public override void Exit()
    {
        
        base.Exit();  
    }
    #endregion
}