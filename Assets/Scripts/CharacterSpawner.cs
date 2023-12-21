using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Spawn character for each client when start game
/// </summary>
public class CharacterSpawner : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterDatabase characterDatabase;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        foreach (var client in MatchplayNetworkServer.Instance.ClientData)
        {
            var character = characterDatabase.GetCharacterById(client.Value.characterId);
            if (character != null)
            {
                var spawnPos = new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
                // Spawn character prefab
                var characterInstance = Instantiate(character.GameplayPrefab, spawnPos, Quaternion.identity);
                // Sau khi Instantiate xong, gán owner cho character
                characterInstance.SpawnAsPlayerObject(client.Value.clientId);
            }
        }
    }
}
