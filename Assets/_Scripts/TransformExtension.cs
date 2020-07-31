using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension 
{
    public static List<Transform> GetAllChildren(this Transform parent, List<Transform> transformList = null)
    {
        if (transformList == null){
            transformList = new List<Transform>();
        }
          
        foreach (Transform child in parent) {
            transformList.Add(child);
            child.GetAllChildren(transformList);
        }
        return transformList;
    }
}