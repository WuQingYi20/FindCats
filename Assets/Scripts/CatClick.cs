using UnityEngine;
using UnityEngine.UI; // �����ʹ�õ���UI Image

public class CatClick : MonoBehaviour
{
    public Color clickedColor = Color.yellow; // ��������ɫ
    public AudioClip meowSound; // è�������ļ�
    private AudioSource audioSource; // ��ƵԴ���

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = meowSound;
    }

    public void OnCatClicked()
    {
        // �ı���ɫ
        GetComponent<Image>().color = clickedColor; // �����ʹ�õ���Sprite Renderer�����滻ΪGetComponent<SpriteRenderer>().color

        // ����è������
        audioSource.Play();
    }
}
