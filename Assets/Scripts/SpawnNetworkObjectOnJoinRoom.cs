using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNetworkObjectOnJoinRoom : MonoBehaviour {

    [RequireComponent(typeof(SpawnNetworkObject))]
    public class SpawnNetworkPlayerOnJoinRoom : Photon.PunBehaviour
    {

        public int a;
        public string name;
        public byte group;
        public Vector3 position;
        public Quaternion rotation;

        public override void OnJoinedRoom()
        {
            GetComponent<SpawnNetworkObject>().SpawnObject(name, position, rotation, group);
        }

    }

}
