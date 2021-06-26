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

        print(currentPlayerData.name);
        print(currentPlayerData.pronouns);
        print(currentPlayerData.gender);
        print(currentPlayerData.isHereForLove);
        print(currentPlayerData.isSameRoomType);

        // change scene? all the relevant attributes are stored in the "currentPlayerData" variable
    }
}
