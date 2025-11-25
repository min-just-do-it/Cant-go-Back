// ============================================
// [PlayerLife.cs]
// 필요한 버튼들 추가:메뉴 -소리설정 재시작 스테이지
// 채력 이미지
// 불러온것: 플레이어 스탯
// ============================================
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public int life = 3;                     // 목숨 기본값
    public TextMeshProUGUI lifeText;         // UI 텍스트
    public GameObject lifeIcon;              // 아이콘 (죽으면 깜빡이거나 효과 가능)

    void Start()
    {
        UpdateLifeUI();
    }

    public void TakeDamage(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            life = 0;
            PlayerDie();
        }

        UpdateLifeUI();
    }

    void UpdateLifeUI()
    {
        lifeText.text = "x " + life;
    }

    void PlayerDie()
    {
        Debug.Log("Game Over!");
        // 리스폰 or 게임오버 화면 불러오기 등
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GetComponent<PlayerLife>().TakeDamage(1);
        }
    }

}
