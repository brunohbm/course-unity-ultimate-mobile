using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public GameObject shopPanel;
    private Player player;
    private int selectedItem;
    private int coast;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {

            player = other.GetComponent<Player> ();

            if (player != null) {
                UIManager.Instance.OpenShop (player.diamonds);
            }

            shopPanel.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "Player") {
            shopPanel.SetActive (false);
        }
    }

    public void SelectItem (int item) {

        selectedItem = item;

        switch (item) {
            case 0:
                UIManager.Instance.setSelectedImagePosition(-154.15f);
                coast = 200;
                break;
            case 1:
                UIManager.Instance.setSelectedImagePosition(-251f);
                coast = 400;
                break;
            case 2:
                UIManager.Instance.setSelectedImagePosition(-348f);
                coast = 100;
                break;
            default:
            break;
        }
    }

    public void BuyItem() {

        if(player.diamonds >= coast) {

            if(selectedItem == 2) {
                GameManager.Instance.HasKeyToFuckingCastle = true;
            }

            player.diamonds -= coast;
            shopPanel.SetActive(false);
        } else {
            shopPanel.SetActive(false);
        }

    }

}