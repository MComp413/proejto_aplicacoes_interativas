using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject tokenListHudPrefab;
    private GameObject openButtonRef;
    private GameObject tokenListHudRef;

    // Start is called before the first frame update
    void Start()
    {
      this.openButtonRef = CreateClosedHUD();
      this.tokenListHudRef = CreateOpenHUD();
      tokenListHudRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    GameObject CreateClosedHUD()
    {
      GameObject openButton = Instantiate(buttonPrefab, transform);
      openButton.transform.GetChild(0).GetComponent<Text>().text = "Options";
      Button buttonRef = openButton.GetComponent<Button>();

      buttonRef.onClick.AddListener(() => {
        tokenListHudRef.SetActive(true);
      });

      return openButton;
    }

    GameObject CreateOpenHUD()
    {
      return Instantiate(tokenListHudPrefab, transform);
    }
}
