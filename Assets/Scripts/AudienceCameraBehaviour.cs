using System.Linq;
using AudienceSDK;
using UnityEngine;

namespace Audience
{
    public class AudienceCameraBehaviour : AudienceCameraBehaviourBase
    {
        public override void Init(AudienceSDK.Camera camera)
        {
            Debug.Log("AudienceCameraBehaviour :: Init");
            UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
            this.DelayedInit(camera);
            // this._cam.cullingMask |= BeatSaberUtils.CustomAvatarFirstPersonExclusionMask;
            // this._streamingCamera.cullingMask |= BeatSaberUtils.CustomAvatarFirstPersonExclusionMask;
        }

        protected override void DelayedInit(AudienceSDK.Camera camera)
        {
            Debug.Log("AudienceCameraBehaviour :: DelayedInit");
            base.DelayedInit(camera);
        }

        protected override void OnGUI()
        {
            base.OnGUI();
        }

        protected override void OnDestroy()
        {
            Debug.Log("AudienceCameraBehaviour :: OnDestroy");
            base.OnDestroy();
        }

        // Update is called once per frame
        void Update()
        {
            GameObject GamePlayer = GameObject.FindGameObjectWithTag("Player");
            
            this.ThirdPersonRot = Quaternion.LookRotation(GamePlayer.transform.position).eulerAngles;
            this.ThirdPersonPos = GamePlayer.transform.position + new Vector3(0, 4, -6);
            //this.ThirdPersonRot = GamePlayer.transform.rotation.eulerAngles;
            //this.transform.rotation = Quaternion.LookRotation(GamePlayer.transform.position);
            //this.transform.LookAt(GamePlayer.transform);
        }
    }
}
