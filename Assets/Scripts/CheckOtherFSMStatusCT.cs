using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class CheckOtherFSMStatusCT : ConditionTask
    {

        public BBParameter<GameObject> FSMHolder;
        public string statueName;

        protected override bool OnCheck()
        {
            //get the fsm owner component from the game object
            var fsmOwner = FSMHolder.value.GetComponent<FSMOwner>();

            //check if the fsm owner and its behaviour are not null
            if (fsmOwner != null && fsmOwner.behaviour != null)
            {
                //get the current state of the fsm
                var currentState = fsmOwner.GetCurrentState();
                //check if the current state is not null and its name matches the specified state name
                if (currentState != null)
                {
                    return currentState.name == statueName;
                }
            }

            return false;
        }
    }
}