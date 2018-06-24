using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObsticalFactory : MonoBehaviour {

    public int randomSkelInt;
    public int randomObsInt;
    public int skelAmount;

    public abstract GameObject chooseSkeleton();
    public abstract GameObject chooseObsticals(GameObject skeleton);

    //state classes call this method
    public abstract GameObject returnObsticalSheet();
    //public abstract void setInactive();

    public List<GameObject> skelList;
    public GameObject[] skeletons;

    public List<GameObject> obsList;
    public GameObject[] obsticals;


    public int skelCount;

    public GameObject obj;
    public GameObject buildObsticalSheet;




}
