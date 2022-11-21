using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice : MonoBehaviour
{
    public string[] keywords = new string[] { "up", "right", "down", "left" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public float speed = 0.5f;

    public UnityEngine.UI.Text results;
    public UnityEngine.UI.Image target;

    protected PhraseRecognizer Recognizer;
    protected string word = "right";

    private void Start()
    {
        if (keywords != null)
        { 
            Recognizer = new KeywordRecognizer(keywords, confidence);
            Recognizer.OnPhraseRecognized += OnPhraseRecognized;
            Recognizer.Start();
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "This is what you said: <b>" + word + "</b>";
    }

    private void Update()
    { 
        var x = target.transform.position.x;
        var y = target.transform.position.y;

        switch (word)
        {
            case "up":
                y += speed;
                break;
            case "down":
                y -= speed;
                break;
            case "right":
                x += speed;
                break;
            case "left":
                x -= speed;
                break;
        }

        target.transform.position = new Vector3(x, y, 0);
    }

    private void OnApplicationQuit()
    {
        if (Recognizer != null && Recognizer.IsRunning)
        {
            Recognizer.OnPhraseRecognized -= OnPhraseRecognized;
            Recognizer.Stop();
        } 
    }

}
