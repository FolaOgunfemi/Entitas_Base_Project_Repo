using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

/// <summary>
/// A system that creates a group with all entites that have a health component, and logs the health of each
/// </summary>
public class LogHealthSystem : IExecuteSystem{
    /// <summary>
    /// should be a group containing all entities of a particular type
    /// </summary>
    readonly IGroup<GameEntity> _entities;
    /// <summary>
    /// NOTE ALL LOGIC IN ENTITAS IN GENERAL SHOULD BE IN A SYSTEM
    /// </summary>
    /// <param name="contexts"></param>
    public LogHealthSystem(Contexts contexts)
    {
        
        //use the GameMatcher as a filter to get us a group that contains all of a certain type of component
        _entities = contexts.game.GetGroup(GameMatcher.Health);
    }


    public void Execute()
    {
        //Print the health of every healthcomponent that has been created
        foreach (var e in _entities)
        {
            var health = e.health.value;
            Debug.Log("Running ExecuteSystem Health Log.. health= " + health);
        }

    //    throw new System.NotImplementedException();
    }


}
