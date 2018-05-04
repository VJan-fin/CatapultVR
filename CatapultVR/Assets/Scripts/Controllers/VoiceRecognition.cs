using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour {
    // maps voice command key phrases to an action (method name)
    private Dictionary<string, string> keywordActions = new Dictionary<string, string>();
    private KeywordRecognizer recognizer;

	// Use this for initialization
	void Start () {
        this.FillKeywords();

        this.recognizer = new KeywordRecognizer(this.keywordActions.Keys.ToArray());
        this.recognizer.OnPhraseRecognized += OnPhraseRecognizesHandler;
        this.recognizer.Start();
    }

    private void OnPhraseRecognizesHandler(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command issued: " + args.text + " with confidence: " + args.confidence);
        Invoke(this.keywordActions[args.text], 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FillKeywords () {
        this.keywordActions.Add("Ball", "SpawnBall");
        this.keywordActions.Add("Square", "SpawnBall");
        this.keywordActions.Add("Spawn ball", "SpawnBall");
    }

    void SpawnBall () {
        Debug.Log("Ball created");
    }
}
