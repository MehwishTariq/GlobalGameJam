using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<RectTransform> uipanels = new List<RectTransform>();
    
    private void Start()
    {
        Time.timeScale = 1;
        Debug.Log("uimanager");
        if (uipanels[0] != null)
        {
            if (!uipanels[0].gameObject.activeSelf)
            {
                uipanels[0].gameObject.SetActive(true);

            }
            uipanels[0].GetComponent<Image>().DOFade(0, 0.7f);
            Invoke("DeactiveFadePanel", 0.8f);

        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void DeactiveFadePanel()
    {
        uipanels[0].gameObject.SetActive(false);
    }

    public IEnumerator LevelComplete()
    {
        DisablePanels();
        uipanels[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        uipanels[2].GetChild(0).GetComponent<Text>().DOFade(1, 0.3f);
        
    }

    public IEnumerator LevelFail()
    {
        DisablePanels();
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0;
        uipanels[3].gameObject.SetActive(true);

    }

    void DisablePanels()
    {
        foreach (var x in uipanels)
        {
            x.gameObject.SetActive(false);
        }
    }
    public void OpenPanel(int i)
    {
        Debug.Log("open");
        DisablePanels();
        uipanels[i].gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
   
   

    public void Play()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 == 4)
            SceneManager.LoadSceneAsync(0);
        else
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Resume()
    {
        uipanels[1].gameObject.SetActive(false);
        uipanels[4].gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
