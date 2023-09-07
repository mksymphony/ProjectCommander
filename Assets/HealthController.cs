using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("�÷��̾��� ü�°� ����")]
    public float currPlaerHealth = 100.0f;
    [SerializeField] private float _maxPlayerHealth = 100.0f;

    [Header("ȭ�� �ֺ��� �Ӱ� �� ���̴� Image")]
    [SerializeField] private Image _redSplatterImage;

    [Header("��ó �̹���")]
    [SerializeField] private Image[] _hurtImage;
    [SerializeField] private float _hurtTime;

    private void Start()
    {
        TakeDamage();
        currPlaerHealth -= 50f;
    }
    IEnumerator HurtFlash()
    {
        int rand = Random.RandomRange(0, _hurtImage.Length);
        _hurtImage[rand].gameObject.SetActive(true);
        _redSplatterImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(_hurtTime);
        _hurtImage[rand].gameObject.SetActive(false);
        _redSplatterImage.gameObject.SetActive(false);
    }
    public void TakeDamage()
    {
        if (currPlaerHealth >= 0)
        {
            StartCoroutine(HurtFlash());
        }
    }
}
