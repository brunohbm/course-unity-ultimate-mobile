using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public void ShowRewardedAd() {
        if(Advertisement.IsReady("reardeedVideo")) {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };

            Advertisement.Show("rewardedVideo", options);
        }
    }

    void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                GameManager.Instance.Player.addDiamonds(100);
                UIManager.Instance.OpenShop(GameManager.Instance.Player.diamonds);
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("The has video failed");
                break;                            
            default:
                break;
        }
    }

}
