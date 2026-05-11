using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NodeCanvas.Tasks.Actions {

	public class PoopOnClickAT : ActionTask {

		public BBParameter<Animator> hamsterAnimator;
		public BBParameter<GameObject> poopPrefab;
		public AnimationClip animationClip;
		public string animationTriggerName;
		public string animationStateName;
		public Transform spawnPoint;
		public Vector3 spawnOffset;
		public float poopLifeTime = 3f;
		public float rayDistance = 100f;
		public LayerMask targetLayers = ~0;
		public bool restorePreviousAnimationAfterCooldown = true;

		float nextAvailableTime;
		float restoreAnimationTime;
		int previousAnimationStateHash;
		bool shouldRestoreAnimation;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			RestoreAnimationAfterCooldown();

			if (Time.time < nextAvailableTime || Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame) {
				return;
			}

			if (Camera.main == null) {
				return;
			}

			var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
			if (!Physics.Raycast(ray, out var hit, rayDistance, targetLayers)) {
				return;
			}

			if (!IsAgentClicked(hit.transform)) {
				return;
			}

			var cooldownTime = GetCooldownTime();
			PlayAnimation(cooldownTime);
			SpawnPoop();
			nextAvailableTime = Time.time + cooldownTime;
		}

		protected override void OnStop() {
		}

		protected override void OnPause() {
		}

		bool IsAgentClicked(Transform clickedTransform) {
			return clickedTransform == agent.transform || clickedTransform.IsChildOf(agent.transform);
		}

		void PlayAnimation(float cooldownTime) {
			if (hamsterAnimator.value == null) {
				return;
			}

			if (restorePreviousAnimationAfterCooldown && cooldownTime > 0f) {
				previousAnimationStateHash = hamsterAnimator.value.GetCurrentAnimatorStateInfo(0).fullPathHash;
				restoreAnimationTime = Time.time + cooldownTime;
				shouldRestoreAnimation = true;
			}

			if (!string.IsNullOrEmpty(animationTriggerName)) {
				hamsterAnimator.value.SetTrigger(animationTriggerName);
				return;
			}

			if (!string.IsNullOrEmpty(animationStateName)) {
				hamsterAnimator.value.Play(animationStateName);
			}
		}

		void SpawnPoop() {
			if (poopPrefab.value == null) {
				return;
			}

			var targetTransform = spawnPoint != null ? spawnPoint : agent.transform;
			var poop = GameObject.Instantiate(poopPrefab.value, targetTransform.position + spawnOffset, Quaternion.identity);
			var autoDestroy = poop.GetComponent<AutoDestroy>();

			if (autoDestroy == null) {
				autoDestroy = poop.AddComponent<AutoDestroy>();
			}

			autoDestroy.lifeTime = poopLifeTime;
		}

		float GetCooldownTime() {
			return animationClip != null ? animationClip.length : 0f;
		}

		void RestoreAnimationAfterCooldown() {
			if (!shouldRestoreAnimation || Time.time < restoreAnimationTime || hamsterAnimator.value == null) {
				return;
			}

			hamsterAnimator.value.Play(previousAnimationStateHash, 0, 0f);
			shouldRestoreAnimation = false;
		}
	}
}
