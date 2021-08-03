﻿using UnityEngine;
using System.Collections;


namespace VREnhancements
{
    class UIFader : MonoBehaviour
    {
        CanvasGroup cg;
        Coroutine fadeCR;
        bool fading = false;
        bool autoFadeOut = false;
        public float autoFadeDelay = 1;

        void Awake()
        {
            cg = this.gameObject.GetComponent<CanvasGroup>();
            if (!cg)
               cg = this.gameObject.AddComponent<CanvasGroup>();
        }

        void Update()
        {
            if (fading)
                return;
            //if the element is visible and autofade is true then auto fade.
            if(autoFadeOut && cg.alpha > 0)
            {
                Fade(0, 1, autoFadeDelay, false);
            }
        }

        public float GetAlpha()
        {
            return cg.alpha;
        }
        public void SetAutoFade(bool enabled)
        {
            autoFadeOut = enabled;
            if (!enabled)
                Fade(AdditionalVROptions.HUD_Alpha, 0, 0, true);
        }
       public void Fade(float targetAlpha, float fadeSpeed = 1, float delaySeconds = 0, bool reset = false)
        {
            //if currently fading and reset true, stop current fade and start new fade
            if (fadeCR != null && fading && reset)
            {
                StopCoroutine(fadeCR);
                fadeCR = StartCoroutine(FadeCG(targetAlpha, fadeSpeed, delaySeconds));
            }
            else if (!fading)
                fadeCR = StartCoroutine(FadeCG(targetAlpha, fadeSpeed, delaySeconds));
        }
        IEnumerator FadeCG(float targetAlpha, float fadeSpeed, float seconds)
        {
            fading = true;
            if(seconds > 0)
                yield return new WaitForSeconds(seconds);
            float newAlpha = cg.alpha;
            if (fadeSpeed <= 0)
                cg.alpha = targetAlpha;
            else
                while (newAlpha != targetAlpha)
                {
                    newAlpha = Mathf.MoveTowards(newAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
                    cg.alpha = newAlpha;
                    yield return null;
                }
            fading = false;
        }
    }
}
