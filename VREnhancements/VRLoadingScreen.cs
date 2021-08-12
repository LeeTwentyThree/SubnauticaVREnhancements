﻿using UnityEngine;
using UnityEngine.UI;

namespace VREnhancements
{
    class VRLoadingScreen : MonoBehaviour
    {
        //Transform UICamera;
        Camera mainCamera;
        Vector3 canvasVelocity = Vector3.zero;
        public static VRLoadingScreen main;
        void Awake()
        {
                main = this;
        }
        void Start()
        { 
            //UICamera = ManagedCanvasUpdate.GetUICamera().transform;
            GameObject go = GameObject.Find("Main Camera");
            if (go)
                mainCamera = go.GetComponent<Camera>();
            //transform.GetComponent<uGUI_CanvasScaler>().distance = AdditionalVROptions.HUD_Distance;
            Image loadingArtwork = uGUI.main.loading.loadingBackground.transform.Find("LoadingArtwork").GetComponent<Image>();
            RectTransform textRect = uGUI.main.loading.loadingText.gameObject.GetComponent<RectTransform>();
            RectTransform logoRect = uGUI.main.loading.loadingBackground.transform.Find("Logo").GetComponent<RectTransform>();
            Vector2 midCenter = new Vector2(0.5f, 0.5f);
            if (loadingArtwork != null && textRect != null && logoRect != null)
            {
                //remove background image and set background to black
                loadingArtwork.sprite = null;
                loadingArtwork.color = Color.black;
                loadingArtwork.GetComponent<RectTransform>().localScale = Vector3.one * 2;//temporary fix for when hud distance is increased
                //center the logo
                logoRect.anchorMin = midCenter;
                logoRect.anchorMax = midCenter;
                logoRect.pivot = midCenter;
                logoRect.anchoredPosition = Vector2.zero;
                //center text and offset below logo
                textRect.anchorMin = midCenter;
                textRect.anchorMax = midCenter;
                textRect.pivot = midCenter;
                textRect.anchoredPosition = new Vector2(0f, -200f);
                textRect.sizeDelta = new Vector2(400f, 100f);
                textRect.gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            }
        }

        /*void OnEnable()
        {
            ManagedCanvasUpdate.AddUICameraChangeListener(new ManagedCanvasUpdate.OnUICameraChange(updateUICamera));
            //Debug.Log("Camera Listener Added");
        }
        void OnDisable()
        {
            ManagedCanvasUpdate.RemoveUICameraChangeListener(new ManagedCanvasUpdate.OnUICameraChange(updateUICamera));
            //Debug.Log("Camera Listener Removed");
        }
        void updateUICamera(Camera camera)
        {
            UICamera = camera.transform;
            //Debug.Log("UICamera Updated to: " + camera.gameObject.name);
        }

        void Update()
        {
            if (!mainCamera)
            {
                Debug.Log("Main Camera null");
                GameObject go = GameObject.Find("MainCamera");
                if (!go)
                    go = GameObject.Find("Main Camera");
                if(go)
                { 
                    mainCamera = go.GetComponent<Camera>();
                    Debug.Log("Main Camera Set to: "+mainCamera.name);
                    //mainCamera.enabled = false;
                }
                else
                    Debug.Log("Cannot find MainCamera or Main Camera");
            }
            if (!UICamera)
            {
                Debug.Log("UI Camera lost");
            }
            else
            {
                //this will stop working when the new scene loads and the UI camera changes to MainCamera (UI) since the new camera no longer tracks the HMD.
                transform.position =
                        Vector3.SmoothDamp(transform.position, UICamera.position + UICamera.forward * AdditionalVROptions.HUD_Distance, ref canvasVelocity, 0.3f);
                transform.rotation = Quaternion.LookRotation(transform.position - UICamera.position, Vector3.up);
            }
        }*/

        public void StartLoading()
        {
            GameObject go = GameObject.Find("Main Camera");
            if (go)
            {
                mainCamera = go.GetComponent<Camera>();
                mainCamera.enabled = false;//make sure only the loading screen is visible
            }
        }
        public void EndLoading()
        {
            /*System.Diagnostics.StackTrace sTrace = new System.Diagnostics.StackTrace();
            for(int i=0;i<sTrace.FrameCount;i++)
            {
                Debug.Log(sTrace.GetFrame(i).GetMethod().ReflectedType.Name+"->"+sTrace.GetFrame(i).GetMethod().Name);
            }*/
        }
    }
}
