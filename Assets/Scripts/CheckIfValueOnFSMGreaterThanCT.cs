using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckIfValueOnFSMGreaterThanCT : ConditionTask {

        public BBParameter<GameObject> targetGameObject;
        public string variableName;
        public float CompareValue;
        Blackboard targetBB;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            //get the blackboard of the target game object
            targetBB = targetGameObject.value.GetComponent<Blackboard>();
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//get the value of the variable from the target blackboard
			float variableValue = targetBB.GetVariable<float>(variableName).value;
			//compare the value to the compare value
            return CompareValue>variableValue;
		}
	}
}