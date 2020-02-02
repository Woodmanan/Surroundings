using UnityEngine;
using UnityEditor;
using System.Collections;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

//Modified by Kristian Helle Jespersen
//June 2011

public class ReplaceGameObjects : ScriptableWizard
{
    public bool copyValues = true;
    public Object NewType;
    public GameObject[] OldObjects;

    public bool oneRecursive = false;
    public GameObject recursiveObject;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        //Transform[] Replaces;
        //Replaces = Replace.GetComponentsInChildren<Transform>();
        if (!oneRecursive)
        {
            foreach (GameObject go in OldObjects)
            {
                GameObject newObject;
                newObject = (GameObject)PrefabUtility.InstantiatePrefab(NewType);
                newObject.transform.position = go.transform.position;
                newObject.transform.rotation = go.transform.rotation;
                newObject.transform.parent = go.transform.parent;

                DestroyImmediate(go);

            }
        }
        else
        {
            for (int i = 0; i < recursiveObject.transform.childCount; i++)
            {
                GameObject go = recursiveObject.transform.GetChild(i).gameObject;
                GameObject newObject;
                newObject = (GameObject)PrefabUtility.InstantiatePrefab(NewType);
                newObject.transform.position = go.transform.position;
                newObject.transform.rotation = go.transform.rotation;
                newObject.transform.parent = go.transform.parent;

                DestroyImmediate(go);
            }
        }

    }
}
