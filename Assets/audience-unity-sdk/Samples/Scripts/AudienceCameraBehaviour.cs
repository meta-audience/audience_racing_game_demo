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

        public void SetFollowTarget(Transform target) {
            this.transform.SetParent(target);
            this.transform.localEulerAngles = Vector3.zero;
            this.transform.localPosition = Vector3.zero;
        }

        protected override void DelayedInit(AudienceSDK.Camera camera)
        {
            Debug.Log("----camera: " + camera.camera_name);
            base.DelayedInit(camera);
            CameraManager.Instance.RegisterCameraBehavior(this);
        }

        protected override void OnGUI()
        {
            base.OnGUI();
        }

        protected override void OnDestroy()
        {
            Debug.Log("----OnDestruy: ");
            CameraManager.Instance.UnregisterCameraBehavior(this);
            base.OnDestroy();
        }
        void Update()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainScene")
            {
                GameObject GamePlayer = GameObject.FindGameObjectWithTag("Player");
                GameObject LookObject = GameObject.Find("EmptyObjectForViewer");
                GameObject CameraObject = GameObject.Find("EmptyObjectForCamera");

                //this.transform.rotation = Quaternion.LookRotation(GamePlayer.transform.position);
                this.transform.position = Vector3.Lerp(this.transform.position, CameraObject.transform.position, 2f * Time.deltaTime);
                /*
                if(Vector3.Distance(this.transform.position, LookObject.transform.position) > 4f)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, CameraObject.transform.position, 2.5f * Time.deltaTime);
                }
                else if (Vector3.Distance(this.transform.position, LookObject.transform.position) < 2f)
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, CameraObject.transform.position, 3f * Time.deltaTime);
                }
                else
                {
                    this.transform.position = Vector3.Lerp(this.transform.position, CameraObject.transform.position, 1.8f * Time.deltaTime);
                }*/
                this.transform.LookAt(LookObject.transform);
                
                //Debug.Log("ThirdPersonPos:"+ this.gameObject.transform.position);
            }
        }
    }
}
