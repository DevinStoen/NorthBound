using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestObsticalFactory : IObsticalFactory{



    void Start()
    {
        skelList = new List<GameObject>();

        //set up level skeleton.
        for (int i = 0; i < skeletons.Length; i++)
        {
            obj = (GameObject)Instantiate(skeletons[i]);
            obj.SetActive(false);
            skelList.Add(obj);
        }

        for (int i = 0; i < obsticals.Length; i++)
        {
            obj = (GameObject)Instantiate(obsticals[i]);
            obj.SetActive(false);
            obsList.Add(obj);
        }
    }

    public override GameObject returnObsticalSheet()
    {
        buildObsticalSheet = chooseSkeleton();
        //chooseObsticals(buildObsticalSheet);

        return chooseObsticals(buildObsticalSheet);
    }


    public override GameObject chooseSkeleton()
    {


        randomSkelInt = UnityEngine.Random.Range(0, skelList.Count);

        while (skelList[randomSkelInt].activeInHierarchy)
        {
            randomSkelInt = UnityEngine.Random.Range(0, skelList.Count);
        }
        skelList[randomSkelInt].SetActive(true);
        return skelList[randomSkelInt];

    }

    //for every skeleton spawn point generate an obstical.
    public override GameObject chooseObsticals(GameObject Skeleton)
    {
        skelCount = Skeleton.GetComponent<skeleton>().getSpawnPointCount();
        //for every spawn position.
        if (skelCount > 0)
        {
            for (int i = 0; i < skelCount; i++)
            {

                randomObsInt = UnityEngine.Random.Range(0, obsList.Count);

                while (obsList[randomObsInt].activeInHierarchy)
                {
                    randomObsInt = UnityEngine.Random.Range(0, obsList.Count);
                }
                obsList[randomObsInt].SetActive(true);
                Skeleton.GetComponent<skeleton>().setObstical(obsList[randomObsInt]);

                //obsList[randomObsInt].transform.position = Skeleton.GetComponent<skeleton>().getSpawnPos(i).position;
            }
        }
        return Skeleton;

    }
    
}
