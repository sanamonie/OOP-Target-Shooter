using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Gun current_Gun;

    [SerializeField]
    Camera pCameraObject;
    [SerializeField]
    Gun[] gunPrefabs;
    Gun[] loadedGuns;
    [SerializeField]
    Transform cameraTransform;



    // Start is called before the first frame update
    void Start()
    {
        loadedGuns = new Gun[gunPrefabs.Length];
        // load all guns as instantiated prefabs
        for (int i = 0; i < gunPrefabs.Length; i++)
        {
            loadedGuns[i] = Instantiate(gunPrefabs[i], Vector3.zero, Quaternion.identity);
        }
        //sets active gun to gun 0
        current_Gun = loadedGuns[0];
        current_Gun.transform.parent = cameraTransform;
        current_Gun.transform.localPosition = new Vector3(.45f,-0.361f,.535f);
        current_Gun.transform.Rotate(-90, 180, 0);
        //disable all non active guns
        for (int i = 1; i < loadedGuns.Length; i++) {
            loadedGuns[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bool var for input
        bool shootDown = Input.GetButtonDown("Fire1");

        if (shootDown)
        {
            current_Gun.fireBullet();
        }
    }

    public void equipGun(int gunIndex){
        if (loadedGuns[gunIndex] != null) {
            //set active gun to disabled
            current_Gun.gameObject.SetActive(false);
            //change active gun
            current_Gun= loadedGuns[gunIndex];
            //activate current gun
            current_Gun.gameObject.SetActive(true);
        }
    }

}
