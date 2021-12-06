using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAOE : MonoBehaviour
{
    
    public GameObject objectPool;
    public int characterIndex;
    public int areaIndex;
    
    private int areaTypesCount = 8;
    public void showEffectArea ()
    {
        GameObject grandChild = objectPool.transform.GetChild(characterIndex).GetChild(areaIndex).gameObject;
        grandChild.SetActive(true);
    }

    public void hideEffectArea ()
    {
        for(int i = 0; i < areaTypesCount; ++i) {
            GameObject grandChild = objectPool.transform.GetChild(characterIndex).GetChild(i).gameObject;
            grandChild.SetActive(false);
        }
    }

}
