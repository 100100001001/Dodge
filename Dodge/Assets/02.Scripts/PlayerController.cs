using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    // �̵� �ӷ�
    public float speed = 8f;

    // �� �ڽ��� ���� ����
    public GameObject my;

    private void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã��
        // playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������� �������� �Է°��� �����ؼ� ����
        float xInput = Input.GetAxis("Horizontal");
        // Horizontal = Input Manager�� ���� Ű��
        // Ű���� 'a', '��' - ���� ���� : -1.0f
        //        'd', '��' - ���� ���� : +1.0f

        float zInput = Input.GetAxis("Vertical");
        // Ű���� 'w', '��' - ���� ���� : +1.0f
        //        's', '��' - ���� ���� : -1.0f

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0f, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // �������� ������ٵ��� �������� ���̾��ٸ�,
        // ���� �������ٵ��� �ӵ�! ���⿡ newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity; // ������ �ƴ�! �ϰ����� �ӵ��� ���ư�
    }

    void DirectInput() // ���̷�Ʈ ���
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }  
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }  
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }  
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }  

    }

    public void Die()
    {
        my.SetActive(false);
        // gameObject.SetActive(false); = ���� ����

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
