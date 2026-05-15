using UnityEngine;

public class Player : MonoBehaviour
{
   public string PlayerName = "Player";
   public int PlayerFlags = 0;
   public DialogueNode PlayerNode;

   public PlayerData ToData()
   {
      return new PlayerData
      {
         Name = PlayerName,
         FlagsReached = PlayerFlags,
         currentDialogueNode = PlayerNode
      };
   }

   public void FromData(PlayerData data)
   {
      PlayerName = data.Name;
      PlayerFlags = data.FlagsReached;
      PlayerNode = data.currentDialogueNode;
   }
}
