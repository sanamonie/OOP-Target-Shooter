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

    int c_Gun_Index = 0;

    int shots_Left = 0;

    // Start is called before the first frame update
    void Start()
    {
        loadedGuns = new Gun[gunPrefabs.Length];
        // load all guns as instantiated prefabs
        for (int i = 0; i < gunPrefabs.Length; i++)
        {
            loadedGuns[i] = Instantiate(gunPrefabs[i], Vector3.zero, Quaternion.identity);
            loadedGuns[i].shotFired += ShotgunShot;
            
            loadedGuns[i].transform.SetParent(cameraTransform, false);
            loadedGuns[i].transform.localPosition = new Vector3(.45f, -0.36f, .53f);
            loadedGuns[i].transform.Rotate(-90, 180, 0, Space.Self);
        }
        //sets active gun to gun 0
        current_Gun = loadedGuns[0];
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

    public void ShotgunShot() {
        Debug.Log(shots_Left);
        if (c_Gun_Index == 1) {
            shots_Left--;
            
        }
        if (shots_Left == 0) {
            equipGun(0);
        }
    }

    public void equipGun(int gunIndex){
        if (loadedGuns[gunIndex] != null ) {
            shots_Left = 3;
            c_Gun_Index = gunIndex;
            //set active gun to disabled
            current_Gun.gameObject.SetActive(false);
            //change active gun
            current_Gun= loadedGuns[gunIndex];
            //activate current gun
            current_Gun.gameObject.SetActive(true);
            //set up active gun 
           // current_Gun.transform.SetParent(cameraTransform,false);
           // current_Gun.transform.rotation = loadedGuns[gunIndex].transform.rotation;
           // current_Gun.transform.localPosition = new Vector3(.45f, -0.361f, .535f);
           // current_Gun.transform.Rotate(-90, 180, 0, Space.Self);
        }
    }

}
