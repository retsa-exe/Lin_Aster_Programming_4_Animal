using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DayCycleAT : ActionTask {

		public BBParameter<bool> isDayTime;
		public float dayDuration;
        float time;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            // Initialize time to 0 at the start of the day cycle
            time = 0;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//increase the time
			time += Time.deltaTime;
			//print the time
			Debug.Log("Time: " + time);
            //check if the time is greater than the day duration
            if (time >= dayDuration)
			{
                //toggle the day time
                isDayTime.SetValue(!isDayTime.value);
				//reset the timer
				time = 0;
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