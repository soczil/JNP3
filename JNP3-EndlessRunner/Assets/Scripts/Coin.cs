using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ulong points = 0;

    public ulong Points
    {
        get
        {
            return points;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            HandlePickup();
        }
    }

    private void HandlePickup()
    {
        GameController.Instance.HandleCoinPickedUp(this);
        Destroy(gameObject);
    }
}