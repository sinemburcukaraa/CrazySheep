using PolygonArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Control : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;

    [SerializeField] private ObjectPooling objectPool = null;
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var obj = objectPool.GetPooledObject(0);
            obj.transform.position = Vector3.zero;
        }

    }
}


//Sürekli ateþ etme kodu
//void Start()
//{
//    StartCoroutine(nameof(SpawnRoutine));
//}

//private IEnumerator SpawnRoutine()
//{
//    int counter = 0;
//    while (true)
//    {

//        // GameObject obj = objectPool.GetPooledObject(counter++ % 2);//2 objeyi sýrayla çaðýrmak istersek bunu kullanmalýyýz
//        var obj = objectPool.GetPooledObject(counter);// ve bunu kaldýr.
//        obj.transform.position = Vector3.zero;

//        yield return new WaitForSeconds(spawnInterval);
//    }
//}