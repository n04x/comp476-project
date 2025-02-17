﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public State current_state;
    public State remain_state;
    public EnemyStats enemy_stats;
    private bool ai_active = true;
    public Transform target;
    
    private void Update()
    {
        if (!ai_active)
            return;
        current_state.UpdateState(this);
    }
    private void OnDrawGizmos()
    {
        if(current_state != null)
        {
            Gizmos.color = current_state.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, enemy_stats.look_sphere_cast_radius);

           

        }
    }

    public void TransitionToState(State next_state)
    {
        if (next_state == null) return;
        if(next_state != remain_state)
        {
            current_state = next_state;
        }
    }
}
