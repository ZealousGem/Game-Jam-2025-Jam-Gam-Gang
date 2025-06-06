using UnityEngine;
using TMPro;
public class SafePuzzle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI detectNum1;
    [SerializeField]
    private TextMeshProUGUI detectNum2;
    [SerializeField]
    private TextMeshProUGUI detectNum3;

    [SerializeField] private GameObject Quiter;
    [SerializeField] private GameObject numChange;
    [SerializeField] private GameObject SafePanel;
    [SerializeField] private GameObject card;
    private bool isSolved;

    public int CodePiece1 = 0;
    public int CodePiece2 = 0;
    public int CodePiece3 = 0;

    void Start()
    {
        isSolved = false;
        card.SetActive(false);
        

    }

   
    void Update()
    {
        

    }
    int ExtractNumber(string input)
    {
        // Use System.Text.RegularExpressions to find a number in the string
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(input, @"\d+");

        if (match.Success)
        {
            return int.Parse(match.Value);
        }

        return -1; 
    }
    public void Enter()
    {

        string text1 = detectNum1.text;
        string text2 = detectNum2.text;
        string text3 = detectNum3.text;

        int number1 = ExtractNumber(text1);
        int number2 = ExtractNumber(text2);
        int number3 = ExtractNumber(text3);

        if (number1 == CodePiece1 && number2 == CodePiece2 && number3 == CodePiece3)
        {
            Debug.Log("Solve Puzzle");
            if (!isSolved) card.SetActive(true);
            Quiter.SetActive(false);
            SafePanel.SetActive(false);
            numChange.SetActive(false);
            isSolved=true;
            try { AudioManager.Instance.PlaySound("victorySound"); } catch { }
            Time.timeScale = 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            try { AudioManager.Instance.PlaySound("UiSound"); } catch { }
        }
    }
}
