using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class UIFollowAT : ActionTask {

		public GameObject UI;
		public Transform targetToFollow;
		public float heightOffset;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			UI.SetActive(true);
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			Vector3 screenPos = Camera.main.WorldToScreenPoint(targetToFollow.position + new Vector3(0, heightOffset, 0));
			UI.transform.position = screenPos;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			UI.SetActive(false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}