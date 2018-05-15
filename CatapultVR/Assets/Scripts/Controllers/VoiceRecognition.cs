using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour {
    // maps voice command key phrases to an action (method name)
    private Dictionary<string, string> keywordActions = new Dictionary<string, string>();
    private KeywordRecognizer recognizer;
	private VoiceManager player;

	// Use this for initialization
	void Start () {
        this.FillKeywords();

        this.recognizer = new KeywordRecognizer(this.keywordActions.Keys.ToArray());
        this.recognizer.OnPhraseRecognized += OnPhraseRecognizesHandler;
        this.recognizer.Start();
		player = GameObject.FindGameObjectWithTag ("PlayerManager").GetComponent<VoiceManager> ();
    }

    private void OnPhraseRecognizesHandler(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command issued: " + args.text + " with confidence: " + args.confidence);
        Invoke(this.keywordActions[args.text], 0);
    }

    void FillKeywords () {
		this.keywordActions.Add ("Ready Catapult", "ReadyCatapult");
		this.keywordActions.Add ("Fire", "PrepareFire");
		this.keywordActions.Add ("Grow Catapult", "GrowCatapult");
		this.keywordActions.Add ("Shrink Catapult", "ShrinkCatapult");
        this.keywordActions.Add ("Explode", "ExplodeCannonBall");
	}

	void ReadyCatapult() {
		player.ReadyCatapult ();
	}

	void PrepareFire() {
		player.PrepareFire ();
	}

	void GrowCatapult(){
		player.GrowCatapult ();
	}

	void ShrinkCatapult(){
		player.ShrinkCatapult ();
	}

    void ExplodeCannonBall() 
    {
        var cannonBalls = FindObjectsOfType<Ball>();
        foreach (var cannonBall in cannonBalls)
        {
            cannonBall.Explode();
        }
    }
}
