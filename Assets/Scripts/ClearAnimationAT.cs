using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ClearAnimationAT : ActionTask {

		Animator hamsterAnimator;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			//get the hamster animator from the blackboard
			hamsterAnimator = agent.GetComponent<Animator>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            // Set all animation states to false
            hamsterAnimator.SetBool("isWalking", false);
            hamsterAnimator.SetBool("isSleeping", false);
            hamsterAnimator.SetBool("isEating", false);
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}