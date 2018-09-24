using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.PunBehaviour
{

    public float speed;

    void Start()
    {
        if (photonView.isMine)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }



    private void Update()
    {

        if (photonView.isMine)
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * speed);
        }
    }


}
