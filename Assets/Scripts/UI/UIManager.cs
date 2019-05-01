using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;

    public static UIManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError ("Instance is null");
            }

            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectedImage;
    public Text diamondsText;
    public Image[] lifeBars;

    public void OpenShop (int gems) {
        playerGemCountText.text = gems + "G";
    }

    private void Awake () {        
        _instance = this;
    }

    public void setSelectedImagePosition(float positionY) {        
        selectedImage.rectTransform.anchoredPosition = new Vector2(selectedImage.rectTransform.anchoredPosition.x, positionY);
    }

    public void setDiamondsText(int diamonds) {
        diamondsText.text = "" + diamonds;
    }

    public void UpdateLives(int lifeRemaining) {
        lifeBars[lifeRemaining].enabled = false;
    }

}