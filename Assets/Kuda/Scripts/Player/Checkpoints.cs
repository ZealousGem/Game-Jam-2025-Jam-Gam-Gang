using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;
    }

    // Update is called once per frame

}
