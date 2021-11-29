using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenItemHUD : MonoBehaviour
{
  public GameObject image;
  public GameObject selectedOption;
  public List<GameObject> aoeOptions;

  // Start is called before the first frame update
  void Start()
  {
    gameObject.GetComponent<Image>().sprite = image;
    gameObject.GetComponent<Dropdown>().onValueChanged.AddListener(this.HandleChange);
  }

  // Update is called once per frame
  void Update()
  {
  }

  void HandleChange(Dropdown target)
  {
    selectedOption = target.value;
    Debug.Log(selectedOption);
  }
}
