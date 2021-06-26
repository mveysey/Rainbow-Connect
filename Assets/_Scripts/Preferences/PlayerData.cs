public class PlayerData {
    public string name;
    public string pronouns; // "(she/her)", "(he/him)", etc.
    public string gender; // male, female, non-binary, etc.
    public bool isHereForLove; // true, false;   false means here for friends
    public bool isSameRoomType; // whether or not to pair player in room of the same gender

    // no parameter constructor
    public PlayerData () {
        name = "";
        pronouns = "(she/her)";
        gender = "female";
        isHereForLove = false;
        isSameRoomType = false;
    }

    // For the menu
    public static string GetPronouns(string gender) {
        if (gender == "male") {
            return "(he/him)";
        } else if (gender == "female") {
            return "(she/her)";
        }
        return "(they/them)";
    }
}
