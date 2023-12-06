using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public List<GameObject> stepList = new List<GameObject>();
    public int index = 0;
    public static BlocksManager instance;
    public bool forceControl;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        forceControl = false;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            stepList.Add(transform.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        if (stepList[stepList.Count - 1].activeInHierarchy &&
            stepList[stepList.Count - 1].GetComponent<StepMovement>().isSettled
            && !forceControl)
        {
            forceControl = true;
            MovementManager.Instance.sheepMovement.StartMovementForStep(); 
        }


    }
    public void NextStep(int index)
    {
        Debug.Log(stepList[index]);
        stepList[index].SetActive(true);
    }

}
