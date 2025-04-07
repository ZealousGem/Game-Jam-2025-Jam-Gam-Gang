using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Respawn();
    }

    public void Respawn()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;
    }
    // Update is called once per frame

}
