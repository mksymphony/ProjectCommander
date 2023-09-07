using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("플레이어의 체력값 설정")]
    public float currPlaerHealth = 100.0f;
    [SerializeField] private float _maxPlayerHealth = 100.0f;

    [Header("화면 주변을 붉게 물 들이는 Image")]
    [SerializeField] private Image _redSplatterImage;

    [Header("상처 이미지")]
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
