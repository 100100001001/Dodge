using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI ���� ���̺귯�� ����ҷ�~
using UnityEngine.UI;
// �� ���� ���� ���̺귯�� ����ҷ�~
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public GameObject gameOverText;
    // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text timeText;
    // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;

    // ���� ���� �ð�
    private float surviveTime;
    // ���� ���� ����
    private bool isGameOver;

    void Start()
    {
        // ���� �ð��� ���� ���� ���� �ʱ�ȭ
        surviveTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        // ���� ������ �ƴ� ����
        if (!isGameOver)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;
        }
    }

    // ���� ������ ���� ���� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���� ���� ���·� ��ȯ
        isGameOver = true;
    }
}
