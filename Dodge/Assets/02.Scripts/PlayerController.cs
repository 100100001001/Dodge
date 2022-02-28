using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    // 이동 속력
    public float speed = 8f;

    // 내 자신을 담을 변수
    public GameObject my;

    private void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아
        // playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지해서 저장
        float xInput = Input.GetAxis("Horizontal");
        // Horizontal = Input Manager에 따른 키값
        // 키보드 'a', '←' - 음의 방향 : -1.0f
        //        'd', '→' - 양의 방향 : +1.0f

        float zInput = Input.GetAxis("Vertical");
        // 키보드 'w', '↑' - 양의 방향 : +1.0f
        //        's', '↓' - 음의 방향 : -1.0f

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0f, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 이전에는 리지디바디의 물리적인 힘이었다면,
        // 이젠 리디지바디의 속도! 여기에 newVelocity 할당
        playerRigidbody.velocity = newVelocity; // 누적이 아님! 일관적인 속도로 나아감
    }

    void DirectInput() // 다이렉트 방식
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
        // gameObject.SetActive(false); = 위와 같음

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
