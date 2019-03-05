using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    RootSystems m_Systems;
    //not necessary when we use Feature Classes for system insatiation
    ReactLogHealthSystem m_TestReactiveSystem;
    //not necessary when we use Feature Classes for system insatiation
    CreatePlayerSystem m_TestPlayerCreateSystem;
    public bool m_UsingFeatureClasses = true;
    /*
     * There are 5 different types of Systems:

IInitializeSystem: Executes once, before the game begins (system.Initialize()).
IExecuteSystem: Executes every frame (system.Execute())
ICleanupSystem: Executes every frame after the other systems are finished (system.Cleanup())
ITearDownSystem: Executes once, after the game ends (system.TearDown())
ReactiveSystem<Entity>: Executes when the observed group changed (system.Execute(Entity[]))
     * */

    private void Start()
    {
        
        if (m_UsingFeatureClasses == false)
        {//NOTE: READ THROUGH THIS FOR TUTORIAL LOGIC on how to use systems
            CreateSystemsDirectly();
        }
        else
        {
            
            m_Systems = new RootSystems(Contexts.sharedInstance);


            m_Systems.Initialize();
        }
    }
    // Use this for initialization
    void CreateSystemsDirectly () {
        RootSystems systems = new RootSystems(Contexts.sharedInstance);
        //systems.E

        //BEST PRACTICE: Contexts.sharedInstance is a useful way to get contexts and expose them to monobehavior scripts as well using a static modifier as op0osed to just createing new Contexts();
        Contexts contexts = Contexts.sharedInstance;
        //STANDARD PRACTICE:this is the standard way of creating contexts at start
        //var contexts = new Contexts();

    ///EXAMPLE ZERO: Initialize entities by using a system as opposed to creating the object in the start or update method
    //BEST PRACTICE: It's best to use systems for all logic, including creating Entities using ?Initialize
         m_TestPlayerCreateSystem = new CreatePlayerSystem(contexts);
        m_TestPlayerCreateSystem.Initialize();
        //STANDARD PRACTICE: this is a simple way to create an entity without using a system to do it
              /*  var e = contexts.game.CreateEntity();
                //No AddComponent with ECS, instead we use the Add method and constructor form the generated IComponent script
                e.AddHealth(100);
                */

    ///EXAMPLE ONE: ExecuteSystems: simply perform when execute method is called
        //Execution logic is generally contained in systems that need to be executed
        var system = new LogHealthSystem(contexts);
        system.Execute();

        ///EXAMPLE TWO: ReactiveSystems: Execute in reaction to some component changing
        m_TestReactiveSystem = new ReactLogHealthSystem(contexts);
    }
	
	// Update is called once per frame
	void Update () {
        ///EXAMPLE TWO cont..:
        if (m_UsingFeatureClasses == false)
        {
            m_TestReactiveSystem.Execute();
        }
        else
        {
            m_Systems.Execute();
        }
    }
}
