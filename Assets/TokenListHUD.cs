using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenListHUD : MonoBehaviour
{
    [SerializeField] private List<Sprite> iconOptions;
    [SerializeField] private List<string> aoeOptions;
    [SerializeField] private GameObject tokenItemPrefab;
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
      var parentRef = gameObject.transform.GetChild(0).GetChild(0);
      int optionsCount = 0;
      foreach (var iconOption in iconOptions)
      {
        GameObject tokenItem = Instantiate<GameObject>(tokenItemPrefab, transform);
        tokenItem.transform.position += new Vector3(0, -100) * optionsCount;
        tokenItem.transform.GetChild(0).GetComponent<Image>().sprite = iconOption;
        var dropdown = tokenItem.transform.GetChild(0).GetComponent<Dropdown>();
        //dropdown.ClearOptions();
        //dropdown.AddOptions(aoeOptions);
        tokenItem.transform.SetParent(parentRef);
        optionsCount++;
      }
    }
}
