using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class CheckOtherFSMStatusCT : ConditionTask
    {

        public BBParameter<GameObject> FSMHolder;
        public string stateName;

        protected override bool OnCheck()
        {
            // 1. 检查黑板参数和其中的 GameObject 是否存在
            if (FSMHolder == null || FSMHolder.value == null)
            {
                return false;
            }

            // 2. 尝试获取 FSMOwner 组件
            var fsmOwner = FSMHolder.value.GetComponent<FSMOwner>();

            // 3. 确保组件存在且行为已初始化
            if (fsmOwner != null && fsmOwner.behaviour != null)
            {
                var currentState = fsmOwner.GetCurrentState();

                // 4. 确保当前有激活的状态，再比对名称
                if (currentState != null)
                {
                    return currentState.name == stateName;
                }
            }

            return false;
        }
    }
}