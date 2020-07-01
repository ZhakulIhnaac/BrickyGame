using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollide : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(GameOverTime());  
    }
    IEnumerator GameOverTime()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndScene");
    }
}
