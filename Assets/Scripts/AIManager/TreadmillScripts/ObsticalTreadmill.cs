using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObsticalTreadmill : MonoBehaviour {

    public List<GameObject> treadmillObsticals;
    public abstract void addLevel(GameObject inObj);
    public abstract void setTotalTimeForLevel(int inTime);

}
