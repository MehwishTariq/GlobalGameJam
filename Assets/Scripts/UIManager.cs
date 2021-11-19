using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<RectTransform> uipanels = new List<RectTransform>();

    public void ChangePanelTo()
    {
        uipanels[0].gameObject.SetActive(false);
        uipanels[2].gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        uipanels[2].gameObject.SetActive(false);
        Time.timeScale = 0;
        uipanels[1].gameObject.SetActive(true);
    }

    public void Close()
    {
        uipanels[1].gameObject.SetActive(false);
        uipanels[2].gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 0;
        foreach(var x in uipanels)
        {
            x.gameObject.SetActive(false);
        }
        uipanels[0].gameObject.SetActive(true);
    }
}
