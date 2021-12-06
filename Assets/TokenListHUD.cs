using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenListHUD : MonoBehaviour
{
    [SerializeField] private List<Sprite> iconOptions;
    [SerializeField] private List<string> aoeOptions;
    [SerializeField] private GameObject tokenItemPrefab;
    [SerializeField] private GameObject buttonPrefab;
    private Dictionary<GameObject, GameObject> iconToAoeMap;
    // Start is called before the first frame update
    void Start()
    {
      InitializeButton();
      LoadIcons();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void InitializeButton(){
      var parentRef = gameObject.transform.GetChild(0).GetChild(0);
      GameObject closeButton = Instantiate(buttonPrefab, transform);
      closeButton.transform.GetChild(0).GetComponent<Text>().text = "Close";
      closeButton.transform.position = new Vector3(80, -15);
      closeButton.transform.SetParent(parentRef);
      Button buttonRef = closeButton.GetComponent<Button>();
      buttonRef.onClick.AddListener(() => {
        gameObject.SetActive(false);
      });
    }

    void LoadIcons()
    {
      var parentRef = gameObject.transform.GetChild(0).GetChild(0);
      int optionsCount = 0;
      var positionVector = new Vector3(160, -100);
      var offsetVector = new Vector3(0, -100);
      foreach (var iconOption in iconOptions)
      {
        GameObject tokenItem = Instantiate<GameObject>(tokenItemPrefab, transform);
        tokenItem.transform.position = positionVector + (offsetVector * optionsCount);
        tokenItem.transform.GetChild(0).GetComponent<Image>().sprite = iconOption;
        var dropdown = tokenItem.transform.GetChild(1).GetComponent<Dropdown>();
        Debug.Log(dropdown);
        dropdown.ClearOptions();
        dropdown.AddOptions(aoeOptions);
        dropdown.onValueChanged.AddListener((int valueIndex) => {
          Debug.Log(iconOption);
          Debug.Log(aoeOptions[valueIndex]);
        });
        tokenItem.transform.SetParent(parentRef);
        optionsCount++;
      }
    }
}
