using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static int Score { get; private set; }

    private void OnTriggerExit2D(Collider2D other)
    {
        var rocket = other.GetComponent<RocketController>();

        if (rocket != null)
        {
            Score++;
            Destroy(gameObject);
        }
    }
}