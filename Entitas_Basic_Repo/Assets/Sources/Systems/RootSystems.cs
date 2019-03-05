using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages our systems so we can organize them
/// Extends Feature Class which is essentially a wrapper for Systems
/// </summary>
/// 
public class RootSystems : Feature {
    /*
     * Entitas Features provide you with some extra control over the organisation your systems. Use them to group related systems together. This has the added benefit of separating the visual debugging objects for your systems in the Unity hierarchy. Now they can be inspected in logical groups instead of all at once.

Features also help you to enforce broader paradigmatic rules in your project. The order of execution of features is determined by the order in which they're added and is always respected by Entitas. Separating your systems into 
InputSystems : Feature, GameLogicSystems : Feature and RenderingSystems : Feature then 
initializing them in that order provides an easy way of ensuring that game logic doesn't interfere with rendering.
     * 
     * */


    public RootSystems(Contexts contexts)
    {
        
        Add(new CreatePlayerSystem(contexts));
        Add(new LogHealthSystem(contexts));
        Add(new ReactLogHealthSystem(contexts));

    }
	// Use this for initialization
	void Start () {
        


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
