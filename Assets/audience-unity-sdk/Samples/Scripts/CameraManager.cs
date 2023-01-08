using System.Collections;
using System.Collections.Generic;
using AudienceSDK;
using AudienceSDK.Sample;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    private static CameraManager instance = null;

    private List<AudienceCameraBehaviour> camBehaviorList = new List<AudienceCameraBehaviour>();

    public Transform neverDie;

    public static CameraManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    public void SetFollowTarget(Transform target) 
    {
        foreach (var camBehavior in this.camBehaviorList)
        {
            camBehavior.SetFollowTarget(target);
        }
    }

    public void RegisterCameraBehavior(AudienceCameraBehaviour camBehavior) 
    {
        if (!this.camBehaviorList.Contains(camBehavior)) {
            this.camBehaviorList.Add(camBehavior);
        }
    }

    public void UnregisterCameraBehavior(AudienceCameraBehaviour camBehavior)
    {
        if (this.camBehaviorList.Contains(camBehavior))
        {
            this.camBehaviorList.Remove(camBehavior);
        }
    }

    private void Awake()
    {
        if (CameraManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        CameraManager.Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene current)
    {
        this.neverDie.transform.eulerAngles = Vector3.zero;
        this.neverDie.transform.position = Vector3.zero;
    }
}
