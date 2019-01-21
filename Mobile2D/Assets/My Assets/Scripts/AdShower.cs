using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdShower : MonoBehaviour
{
    public static void showAd() {
        Advertisement.Show();
    }

    public void showRewardedAd() {
        const string RewardedPlacementId = "rewardedVideo";

        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //resets the game but teh score stills the same (extra life)
                if (Data_Bridge.colorMode)
                {
                    SceneManager.LoadScene("ColorMode");
                }
                else
                {
                    SceneManager.LoadScene("Main");
                }
                
                break;
            case ShowResult.Skipped:
                //If the player skips the ad, th game will be over
                SceneManager.LoadScene("GameOverScreen");
                break;
            case ShowResult.Failed:
                //If the ad can't be shown, the game will be over
                SceneManager.LoadScene("GameOverScreen");
                break;
        }
    }
}
