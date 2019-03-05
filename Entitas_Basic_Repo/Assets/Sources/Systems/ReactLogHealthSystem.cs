using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

/// <summary>
/// A system that creates a group with all entites that have a health component, and logs the health of each
/// </summary>
public class ReactLogHealthSystem : ReactiveSystem<GameEntity>
{

    public ReactLogHealthSystem(Contexts contexts): base(contexts.game)
    {

 }

    /// <summary>
    /// Defines which changes wsill trigger the system
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Health);
    }


    protected override void Execute(List<GameEntity> entities)
    {
        //Print the health of every healthcomponent that has been created
        foreach (var e in entities)
        {
            var health = e.health.value;
            Debug.Log("printing reactive health value: " + health);
        }
    }

    /// <summary>
    /// Whenever we access a field from a component, we should filter it first to make sure that we actually have it
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected override bool Filter(GameEntity entity)
    {
       return entity.hasHealth;
    }


}
