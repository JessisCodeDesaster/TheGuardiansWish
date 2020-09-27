using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextDungeon : MonoBehaviour
{
    public Image bg;
    public Text introtext;
    public Text attackspeed;
    public Text attackrate;
    public Text movementspeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController.change(false);
        bg.canvasRenderer.SetAlpha(1.0f);
        introtext.canvasRenderer.SetAlpha(1.0f);

        attackspeed.canvasRenderer.SetAlpha(0.0f);
        attackrate.canvasRenderer.SetAlpha(0.0f);
        movementspeed.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 2.5f)
        {
            fadeOut();
            characterController.change(true);
        }
    }

    void fadeOut()
    {
        bg.CrossFadeAlpha(0, 0.1f, true);
        introtext.CrossFadeAlpha(0, 0.1f, true);
    }
}
