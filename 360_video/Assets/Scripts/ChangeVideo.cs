using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeVideo : MonoBehaviour
{
    public VideoClip clip01;
    public VideoClip clip02;
    bool isClip02;
    private int isPlaying = 0;

    public void Change02()
    {
        if (!isClip02)
        {
            gameObject.GetComponent<VideoPlayer>().clip = clip02;
            isClip02 = true;
        }
        else
        {
            if(isPlaying == 0)
            {
                gameObject.GetComponent<VideoPlayer>().Pause();
                isPlaying = 1;
            }
            else if(isPlaying == 1)
            {
                gameObject.GetComponent<VideoPlayer>().Play();
                isPlaying = 0;
            }
        }
    }

    public void Change01()
    {
        if (isClip02)
        {
            gameObject.GetComponent<VideoPlayer>().clip = clip01;
            isClip02 = false;
        }
        else
        {
            if(isPlaying == 0)
            {
                gameObject.GetComponent<VideoPlayer>().Play();
                isPlaying = 1;
            }
            else if(isPlaying == 1)
            {
                gameObject.GetComponent<VideoPlayer>().Pause();
                isPlaying = 0;
            }
        }
    }
}
