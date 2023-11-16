using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Database", menuName = "Characters/Database")]
public class CharacterDatabase : ScriptableObject
{
    [SerializeField] private Character[] characters = new Character[0];

    public Character[] GetAllCharacters() => characters;

    public Character GetCharacterById(int id)
    {
        foreach(var character in characters)
        {
            if(character.Id == id)
            {
                return character;
            }
        }

        return null;
    }


    /// <summary>
    /// Check ID được pass có đúng với bất kì tướng nào hay k
    /// </summary>
    public bool IsValidCharacterId(int id)
    {
        return characters.Any(x => x.Id == id);
    }
}
