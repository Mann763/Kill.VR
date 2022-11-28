using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Handpresence : MonoBehaviour
{
    public bool Showcontroller = false;
    public InputDeviceCharacteristics controllerCharacteristic;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject SpawnController;
    private GameObject SpawnedHandModel;
    private Animator handAnimator;

    private playerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        TryInitilised();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    void TryInitilised()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not finf Corresponding Controller model");
                SpawnController = Instantiate(controllerPrefabs[0], transform);
            }

            SpawnedHandModel = Instantiate(handModelPrefab, transform);
            playerHealth.healthBar = GetComponent<ProgressBarPro>();
            playerHealth.healthBar.SetValue(playerHealth.maxHealth);
            handAnimator = SpawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitilised();
        }
        else
        {
            if (Showcontroller)
            {
                SpawnedHandModel.SetActive(false);
                SpawnedHandModel.SetActive(true);
            }
            else
            {
                SpawnedHandModel.SetActive(true);
                SpawnedHandModel.SetActive(false);
                UpdateHandAnimation();
            }
        }    
    }
}
