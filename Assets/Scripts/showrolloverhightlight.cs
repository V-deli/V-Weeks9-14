using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showrolloverhightlight : MonoBehaviour
{
    public Image image;
    public Sprite highlight;
    public Sprite normal;
    public TextMeshProUGUI reactiontext;

    public void MouseIsOverUs()
    {
        image.sprite = highlight;
        reactiontext.text = "Blergh";
    }

    public void MouseNotOverUs()
    {
        image.sprite = normal;
        reactiontext.text = "Yumm";
    }
}
