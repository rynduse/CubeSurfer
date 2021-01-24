using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour, ICollactable
{
    public Text coinText;
    public AudioSource audioSource;

    public void Collect()
    {
        GameManager.Instance._coinAmount++;
        coinText.text = GameManager.Instance._coinAmount.ToString();
        StartCoroutine(WaitSound());
    }

    IEnumerator WaitSound()
    {
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        audioSource.Play();
        render.enabled = false;
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }
}
