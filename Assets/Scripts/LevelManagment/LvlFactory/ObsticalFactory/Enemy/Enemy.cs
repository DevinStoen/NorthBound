using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public abstract void control(string inBehavior);
    public abstract void setControl(string inBehavior);
    public string behavior = "";
    public bool seen;
    public abstract void setSeen(bool seen);

}
