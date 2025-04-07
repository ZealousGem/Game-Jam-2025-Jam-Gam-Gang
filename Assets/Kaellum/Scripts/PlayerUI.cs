using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    private static PlayerUI Instance;


    //public Button QuitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        promptText = GameObject.FindGameObjectWithTag("Interact").GetComponent<TextMeshProUGUI>();

    }

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
           
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateText(string promptmessage)
    {
        promptText.text = promptmessage;

    }
}
