using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public GameObject bulletPrefab;

    public Transform barrel;

    public Transform camTrans;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

            RaycastHit hit;

            if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, 50f))
            {
                if (Vector3.Distance(camTrans.position, hit.point) > 2f)
                {
                    barrel.LookAt(hit.point);
                }
            }
            else
            {
                barrel.LookAt(camTrans.position + (camTrans.forward * 45f));
            }


            GameObject bulletinst = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        }
       
    }
}
