using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeProfile : MonoBehaviour
{
    PlayerData currentPlayerData = new PlayerData(); // New player data by default

    public InputField nameText;
    public InputField pronounsText;
    public InputField genderText;
    public MenuController menuController;
    //public GameObject canvas;

    // MENU BUTTONS 

    public void ChangeGender(string gender) {
        currentPlayerData.gender = gender;
        pronounsText.text = PlayerData.GetPronouns(gender);
    }

    public void ChangeLookingForLove(bool isLookingForLove) {
        currentPlayerData.isHereForLove = isLookingForLove;
    }

    public void ChangeRoomType(bool isSameRoom) {
        currentPlayerData.isSameRoomType = isSameRoom;
    }

    public void Submit() {
        currentPlayerData.name = nameText.text;
        currentPlayerData.pronouns = pronounsText.text;

        if (currentPlayerData.gender == "other") {
            currentPlayerData.gender = genderText.text;
        }

        menuController.playerData = currentPlayerData;
        menuController.SetUserName();
        //canvas.SetActive(false);
    }
}
