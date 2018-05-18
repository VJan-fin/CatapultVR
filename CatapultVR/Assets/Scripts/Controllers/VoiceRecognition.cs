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
        this.keywordActions.Add("Fire", "PrepareFire");
		this.keywordActions.Add("Fire Catapult", "PrepareFire");
		this.keywordActions.Add("Go nuts on that castle", "PrepareFire");
        this.keywordActions.Add("Make it rain fire", "PrepareFire");

        this.keywordActions.Add("Ready Catapult", "ReadyCatapult");
		this.keywordActions.Add("Prepare Catapult", "ReadyCatapult");
		this.keywordActions.Add("Steady", "ReadyCatapult");

		this.keywordActions.Add("Explode", "ExplodeCannonBall");
		this.keywordActions.Add("Kaboum", "ExplodeCannonBall");
		this.keywordActions.Add("Boum Boum", "ExplodeCannonBall");

		this.keywordActions.Add ("Start Game", "StartGame");
        this.keywordActions.Add("Restart Game", "StartGame");
        this.keywordActions.Add ("Go let's go", "StartGame");
		this.keywordActions.Add ("Vamos", "StartGame");
		this.keywordActions.Add ("Yalla Habibi", "StartGame");

		this.keywordActions.Add("Reset cannonballs", "ResetCannonballs");
		this.keywordActions.Add("Give me my balls back", "ResetCannonballs");
		this.keywordActions.Add("Bring back the balls", "ResetCannonballs");

        this.keywordActions.Add("Grow Catapult", "GrowCatapult");
        this.keywordActions.Add("Shrink Catapult", "ShrinkCatapult");
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

    public void ExplodeCannonBall() 
    {
        player.ExplodeCannonBall();
    }

    public void ResetCannonballs()
    {
        player.ResetCannonballs();
    }

	public void StartGame() {
		player.StartGame ();
	}
}
