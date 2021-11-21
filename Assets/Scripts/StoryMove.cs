using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StoryMove : MonoBehaviour
{
    public GameObject ImagePanel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayStory());
       
    }

    IEnumerator PlayStory()
    {
        for (int i = ImagePanel.transform.childCount - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(4f);
            ImagePanel.transform.GetChild(i).GetComponent<Image>().DOFade(0, 3f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
