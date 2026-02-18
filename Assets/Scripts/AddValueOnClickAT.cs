using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NodeCanvas.Tasks.Actions {

	public class AddValueOnClickAT : ActionTask {

		public BBParameter<float> variable;
		public float addValue;
		public LayerMask targetLayers;

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
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
			{
                // Check for mouse click
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;

                //if hit, add value to variable
                if (Physics.Raycast(ray, out hit, 100f, targetLayers))
                {
                    variable.SetValue(variable.value + addValue);
                    EndAction(true);
                }
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