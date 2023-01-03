using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudienceSDK;

namespace AudienceSDK.Sample
{
    public class AudienceCameraBehaviour : AudienceCameraBehaviourBase
    {
        public override void Init(AudienceSDK.Camera camera)
        {
            UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
            this.DelayedInit(camera);
        }

        protected override void DelayedInit(AudienceSDK.Camera camera)
        {
            base.DelayedInit(camera);
        }

        protected override void OnGUI()
        {
            base.OnGUI();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        void Update()
        {
            GameObject GamePlayer = GameObject.FindGameObjectWithTag("Player");

            //this.ThirdPersonRot = Quaternion.LookRotation(GamePlayer.transform.position).eulerAngles;
            //this.ThirdPersonRot = GamePlayer.transform.rotation.eulerAngles;
            this.transform.rotation = Quaternion.LookRotation(GamePlayer.transform.position);
            this.ThirdPersonPos = GamePlayer.transform.position + new Vector3(0, 4, -6);
            //this.transform.LookAt(GamePlayer.transform);
        }
    }
}
