using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 자동차 태그 확인
        {
            Debug.Log("가스 충돌");
            RacingGameManagert gameManager = FindObjectOfType<RacingGameManagert>();
            if (gameManager != null)
            {
                gameManager.AddGas(30f);
            }
            Destroy(gameObject); // 가스 아이템 제거
        }
    }
}
