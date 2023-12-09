using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu]
public class ShellDatabase : ScriptableObject
{
   public Shells[] shells;

   public int CharacterCount
   {
        get
        {
            return shells.Length;
        }
   }

   public Shells GetCharacter(int index)
   {
        return shells[index]; 
   }
}
