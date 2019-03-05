using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public sealed class CreatePlayerSystem : IInitializeSystem {

    readonly Contexts m_contexts;

    public CreatePlayerSystem(Contexts contexts)
    {
        m_contexts = contexts;
    }

    public void Initialize()
    {
        Debug.Log("Initialize Method of CreatePlayerSyste, creating Health Entity");
        var e = m_contexts.game.CreateEntity();
        //No AddComponent with ECS, instead we use the Add method and constructor form the generated IComponent script
        e.AddHealth(100);
    }


}
