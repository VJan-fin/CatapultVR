using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int score { get; private set; }
    public TextMesh scoreMesh;

    void Start()
    {
        score = 0;
        scoreMesh.text = "0";
    }

	public void Destroyed(Destructible destructible)
    {
        score += 1;
        scoreMesh.text = score.ToString();
    }
}
