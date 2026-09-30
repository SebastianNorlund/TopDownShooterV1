using UnityEngine;
using TMPro;
public class EnemyCounterScript : MonoBehaviour
{
    private TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length; //finds how many gameobjects tagged enemy exist currently
        text.text = "Enemies left: " + enemiesLeft;
    }
}
