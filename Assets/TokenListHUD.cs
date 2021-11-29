using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenListHUD : MonoBehaviour
{
    [SerializeField] private List<GameObject> iconOptions;
    [SerializeField] private List<GameObject> aoeOptions;
    [SerializeField] private GameObject tokenItemPrefab;
    private List<GameObject> tokenItemsRefList;
    private Dictionary<GameObject, GameObject> iconToAoeMap;
    // Start is called before the first frame update
    void Start()
    {
      LoadIcons();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void LoadIcons()
    {
      foreach (var iconOption in iconOptions)
      {
        var itemRef = Instantiate(tokenItemPrefab);
        itemRef.icon = iconOption;
        tokenItemsRefList.push(itemRef);
      }
    }
}
