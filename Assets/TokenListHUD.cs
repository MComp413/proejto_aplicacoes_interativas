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
    private GameObject objectPool;
    private int characterCount = 8;
    private int areaTypesCount = 8;

    // Start is called before the first frame update
    void Start()
    {
      objectPool = GameObject.Find("ObjectPool");
      Debug.Log("objectPool: " + objectPool);
      InitializeButton();
      LoadIcons();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void showEffectArea (int characterIndex, int areaIndex)
    {
        Debug.Log("characterIndex: " + characterIndex);
        Debug.Log("areaIndex: " + areaIndex);
        Debug.Log("transformLength " + this.objectPool.transform.childCount);
        GameObject grandChild = this.objectPool.transform.GetChild(characterIndex).GetChild(areaIndex).gameObject;
        grandChild.SetActive(true);
    }

    public void hideEffectArea (int characterIndex)
    {
        for(int i = 0; i < areaTypesCount; ++i) {
            GameObject grandChild = this.objectPool.transform.GetChild(characterIndex).GetChild(i).gameObject;
            grandChild.SetActive(false);
        }
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
      for(int characterIndex = 0; characterIndex < characterCount; ++characterIndex)
      {
        var iconOption = iconOptions[characterIndex];
        GameObject tokenItem = Instantiate<GameObject>(tokenItemPrefab, transform);
        tokenItem.transform.position = positionVector + (offsetVector * optionsCount);
        tokenItem.transform.GetChild(0).GetComponent<Image>().sprite = iconOption;
        var dropdown = tokenItem.transform.GetChild(1).GetComponent<Dropdown>();
        Debug.Log(dropdown);
        dropdown.ClearOptions();
        dropdown.AddOptions(aoeOptions);
        dropdown.onValueChanged.AddListener((int valueIndex) => {
          var dropdownSprite = tokenItem.transform.GetChild(0).GetComponent<Image>().sprite;
          var charIndex = iconOptions.IndexOf(dropdownSprite);
          Debug.Log("charIndex:  " + charIndex);
          if (valueIndex == 0) {
            hideEffectArea (charIndex);
          } else {
            showEffectArea(charIndex, valueIndex-1);
          }
        });
        tokenItem.transform.SetParent(parentRef);
        optionsCount++;
      }
    }
}
