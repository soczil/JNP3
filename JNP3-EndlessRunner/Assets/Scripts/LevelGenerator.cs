using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE = 100f;

    [SerializeField]
    private Transform startLevel;

    [SerializeField]
    private Transform levelPart1;

    private GameObject player;
    private Vector3 lastLevelEnd;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastLevelEnd = startLevel.Find("LevelEnd").position;
    }

    private void Update() {
        if (Vector3.Distance(player.transform.position, lastLevelEnd) < PLAYER_DISTANCE)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastLevelEnd);
        lastLevelEnd = lastLevelPartTransform.Find("LevelEnd").position;
    }

    private Transform SpawnLevelPart(Vector3 position)
    {
        Transform levelPartTransform = Instantiate(levelPart1, position, Quaternion.identity);
        return levelPartTransform;
    }
}
