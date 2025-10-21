using System.Collections.Generic;
using UnityEngine;

public class BatFollowMouse : MonoBehaviour
{
    private List<GameObject> frogsInRange = new List<GameObject>();
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0)) // left click
        {
            foreach (GameObject frog in frogsInRange)
            {
                if (frog != null)
                {
                    Destroy(frog);
                    if (scoreManager != null)
                    {
                        scoreManager.AddScore(1);  // Add 1 point per frog killed
                    }
                }
            }
            frogsInRange.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Frog"))
        {
            frogsInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Frog"))
        {
            frogsInRange.Remove(other.gameObject);
        }
    }
}
