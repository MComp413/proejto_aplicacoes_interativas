using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenItemHUD : MonoBehaviour
{
  public GameObject selectedOption;

  // Start is called before the first frame update
  void Start()
  {
    gameObject.GetComponent<Dropdown>().onValueChanged.AddListener((int value_idx) => {
      HandleChange(value_idx);
    });
  }

  // Update is called once per frame
  void Update()
  {
  }

  void HandleChange(int value_idx)
  {
    Debug.Log(value_idx);
  }
}
