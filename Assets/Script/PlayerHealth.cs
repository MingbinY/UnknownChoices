using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public AudioClip takeHitClip;
    public GameObject bloodyScreen;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (takeHitClip != null && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(takeHitClip);
        }
        StartCoroutine(BloodyScreenEffect());
    }

    public override void Death()
    {
        if (isPlayer)
        {
            GameManager.Instance.GameOver(false);
        }
        else
        {
            //Enemy died
            LevelManager.Instance.waveManager.EnemyKilled();
            Destroy(gameObject);
        }

        GetComponent<AudioSource>().PlayOneShot(deathClip);
    }

    private IEnumerator BloodyScreenEffect(){

    // 检查bloodyScreen是否处于非激活状态，如果是则将其激活
    if (!bloodyScreen.activeInHierarchy)
    {
        bloodyScreen.SetActive(true);
    }

    // 获取bloodyScreen下的Image组件
    var image = bloodyScreen.GetComponentInChildren<Image>();
    Debug.Log("TakeDamageInPlayerHealth");
    // 设置初始alpha值为1（完全可见）
    Color startColor = image.color;
    startColor.a = 1f;
    image.color = startColor;

    float duration = 3f;
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
        // 使用Lerp计算新的alpha值
        float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

        // 更新颜色的alpha值
        Color newColor = image.color;
        newColor.a = alpha;
        image.color = newColor;

        // 增加经过的时间
        elapsedTime += Time.deltaTime;

        yield return null; // 等待下一帧
    }

    // 检查bloodyScreen是否处于激活状态，如果是则将其关闭
    if (bloodyScreen.activeInHierarchy)
    {
        bloodyScreen.SetActive(false);
    }
}
}

