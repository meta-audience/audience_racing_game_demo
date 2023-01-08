using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudienceSDK.Sample;

public class CameraTriggers : MonoBehaviour
{
    [SerializeField]
    private Transform attachTransform;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OnCollisionEnter:" + this.gameObject.name);
            if (this.attachTransform != null)
            {
                CameraManager.Instance.SetFollowTarget(this.attachTransform);
            }
            else
            {
                CameraManager.Instance.neverDie.eulerAngles = this.transform.eulerAngles;
                CameraManager.Instance.neverDie.position = this.transform.position;
                CameraManager.Instance.SetFollowTarget(CameraManager.Instance.neverDie);
            }
            this.GetComponent<Collider>().enabled = false;
        }

    }
}
