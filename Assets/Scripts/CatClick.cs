using UnityEngine;
using UnityEngine.UI; // 如果你使用的是UI Image

public class CatClick : MonoBehaviour
{
    public Color clickedColor = Color.yellow; // 点击后的颜色
    public AudioClip meowSound; // 猫叫声音文件
    private AudioSource audioSource; // 音频源组件

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = meowSound;
    }

    public void OnCatClicked()
    {
        // 改变颜色
        GetComponent<Image>().color = clickedColor; // 如果你使用的是Sprite Renderer，则替换为GetComponent<SpriteRenderer>().color

        // 播放猫叫声音
        audioSource.Play();
    }
}
