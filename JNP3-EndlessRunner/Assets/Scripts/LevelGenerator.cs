using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE = 100f;

    [SerializeField]
    private Transform startLevel;

    [SerializeField]
    private List<Transform> levelParts;

    private GameObject player;
    private Vector3 lastLevelEnd;
    private List<Transform> activeLevelParts = new List<Transform>();
    private Vector3 firstActiveLevelPartStart;
    private Vector3 firstActiveLevelPartEnd;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastLevelEnd = startLevel.Find("LevelEnd").position;
        activeLevelParts.Add(startLevel);
        firstActiveLevelPartStart = startLevel.Find("LevelStart").position;
        firstActiveLevelPartEnd = lastLevelEnd;
    }

    private void Update() 
    {
        if (player == null)
        {
            return;
        }

        if (Vector3.Distance(player.transform.position, lastLevelEnd) < PLAYER_DISTANCE)
        {
            SpawnLevelPart();
        }

        if (Vector3.Distance(player.transform.position, firstActiveLevelPartEnd) 
            > 2 * Vector3.Distance(firstActiveLevelPartStart, firstActiveLevelPartEnd))
        {
            DestroyLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform randomLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(randomLevelPart, lastLevelEnd);
        lastLevelEnd = lastLevelPartTransform.Find("LevelEnd").position;
        activeLevelParts.Add(lastLevelPartTransform);
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 position)
    {
        Transform levelPartTransform = Instantiate(levelPart, position, Quaternion.identity);
        return levelPartTransform;
    }

    private void DestroyLevelPart()
    {
        Transform levelPartToDestroy = activeLevelParts[0];
        activeLevelParts.RemoveAt(0);
        Destroy(levelPartToDestroy.gameObject);
        firstActiveLevelPartStart = activeLevelParts[0].Find("LevelStart").position;
        firstActiveLevelPartEnd = activeLevelParts[0].Find("LevelEnd").position;
    }
}
