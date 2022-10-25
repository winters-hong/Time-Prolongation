using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class VideoCapture : MonoBehaviour
{
    int cameraId = 1;
    WebCamTexture currentWebCam;

    public Material VideoTest;


    void Start()
    {
        StartCoroutine(Call());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SwitchCamera();
    }

    void OnDestroy()
    {
        if (currentWebCam != null)
            currentWebCam.Stop();
    }

    public IEnumerator Call()
    {
        // 请求权限
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam) && WebCamTexture.devices.Length > 0)
        {
            if(WebCamTexture.devices.Length == 1)
                cameraId = 0;
            // 创建相机贴图
            currentWebCam = new WebCamTexture(WebCamTexture.devices[cameraId].name, 2048, 1080, 30);
            //把贴图赋给材质
            VideoTest.SetTexture("_UnlitColorMap", currentWebCam);
            currentWebCam.Play();
        }
        else Debug.LogError("未获取摄像头权限");
    }

    //切换摄像头
    public void SwitchCamera()
    {
        if (WebCamTexture.devices.Length < 1)
            return;

        if (currentWebCam != null)
            currentWebCam.Stop();

        cameraId++;
        cameraId = cameraId % WebCamTexture.devices.Length;

        // 创建相机贴图
        currentWebCam = new WebCamTexture(WebCamTexture.devices[cameraId].name, 2048, 1080, 30);
        //把贴图赋给材质
        VideoTest.SetTexture("_UnlitColorMap", currentWebCam);
        currentWebCam.Play();
    }

}