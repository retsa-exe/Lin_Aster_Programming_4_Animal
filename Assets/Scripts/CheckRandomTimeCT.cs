using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckRandomTimeCT : ConditionTask {

		public float minTime = 5;
		public float maxTime = 15;

		float currentTime;
		float targetTime;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			//reset the timer
			currentTime = 0f;

            //get a random target time
            targetTime = Random.Range(minTime, maxTime);
        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			//start the timer
			currentTime += Time.deltaTime;
			if (currentTime >= targetTime)
			{
				//reset the timer and get a new random target time
				currentTime = 0f;
				targetTime = Random.Range(minTime, maxTime);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}