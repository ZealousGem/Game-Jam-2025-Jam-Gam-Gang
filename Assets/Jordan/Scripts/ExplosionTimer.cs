using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ExplosionTimer Instance { get; private set; }
    public bool beginTime;
   public bool startExpo;
    public bool endSeq;
    public float MouseSnesitivity;
    public int timer { private set; get; }

    [SerializeField]
    float clock = 120f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        endSeq = false;
        startExpo = false;
        beginTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginTime)
        {
            clock -= Time.deltaTime;
            timer = (int)clock;
        }
    }

    public float GetTime()
    {
        return timer;
    }

    public void Reset()
    {
        clock = 120f;
        timer = (int)clock;

    }
}
