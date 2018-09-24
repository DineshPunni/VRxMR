using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SpawnNetworkObject : MonoBehaviour
    {

        public List<GameObject> spawnedObjects = new List<GameObject>();


        public void SpawnObject(string name, Vector3 postition, Quaternion rotation, byte group = 0)
        {
            var tmp = PhotonNetwork.Instantiate(name, postition, rotation, group);
            spawnedObjects.Add(tmp);
        }
    }

