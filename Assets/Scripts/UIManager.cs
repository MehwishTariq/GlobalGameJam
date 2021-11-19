using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<RectTransform> uipanels = new List<RectTransform>();

    public void ChangePanelTo(RectTransform nextPanel)
    {
        transform.gameObject.GetComponentInParent<Image>().CrossFadeAlpha(0, 0.1f, true);
    }
    
}
