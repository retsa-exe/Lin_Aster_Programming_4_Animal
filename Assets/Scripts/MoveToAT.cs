using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToAT : ActionTask {

		public BBParameter<Animator> hamsterAnimator;

		public BBParameter<NavMeshAgent> navMeshAgent;

        public BBParameter<Transform> targetTransform;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			navMeshAgent.value.SetDestination(targetTransform.value.position);

			if (Vector3.Distance(targetTransform.value.position, navMeshAgent.value.transform.position) < 0.3f)
			{
				hamsterAnimator.value.SetBool("isWalking", false);
				EndAction(true);
            }
			else
			{
				hamsterAnimator.value.SetBool("isWalking", true);
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}