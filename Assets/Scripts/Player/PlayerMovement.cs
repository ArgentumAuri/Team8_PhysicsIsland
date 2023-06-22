using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("���������� ��������� � ����������")]
    public Animator _anim; // �������� ������ � ����������, ����������� �� ��������
    public CharacterController _char; // �������� ������ � ����������, ����������� �� ������������ ���������
    Transform PlayerTransform;

    [Header("������� ��������")]
    Vector3 direction; // ������ ������ ����� �������� �� ��, ���� ����� ���� ��������
    Vector3 PlayerRotate; // ������ ������ ����� �������� �� ������� ��������� �� ��� �
    Vector3 ChestRotate; // ������ ������ ����� �������� �� ������� ����� �� ��� Y. ��������� ��� ����, ����� ����� ������� �����

    [Header("������� ��� �������������")]
    public Transform Chest; // ������ ��������� ��������� ��� �������� �����.

    [Header("���������� ��� �������� ���������")]
    public float speed = 7f;
    public float runSpeed = 14f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    public float moveSpeed;

    [Header("���������� ��� ���������� ���������� �����")]
    public float MouseX;
    public float MouseY;
    private float mouseSensetivity = 300f;
    //public float currentSense = 300f;



    [Header("������ ������ ����. ����� ��� ������ ������")]
    public float aiming;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���������� �������� �������
        _anim = GetComponent<Animator>(); // ����������� �������� � ����������, ����� ���� ������� ��� ������������
        _char = GetComponent<CharacterController>(); // �� �� ����� � CharacterControll
        moveSpeed = speed;

    }



    void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        GetRotate(); // ��������� ����� � LateUpdate. � ���� ������ ������� ����������� ����� Update. ��� ��� ��� ���� �������. ����� ���� � � Update ��������
    }

    private void GetInput() // ����� ����� ���, ��� �������� � ������ ������ � ���������� � ����
    {
        float x = Input.GetAxis("Horizontal"); // ��������� ��� ���������� ��� ������������ �� ��� X. ���������� ��� ��� ����� ������ ��������� ����������
        float z = Input.GetAxis("Vertical");// ��������� ��� ���������� ��� ������������ �� ��� Z. ���������� ��� ��� ����� ������ ��������� ����������
        MouseX = Mathf.Clamp(Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime, -80f, 80f); // ������ �������� ��� ��� � ����.
        MouseY = Mathf.Clamp(Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime, -80f, 80f); // ������ �������� ��� ��� Y ����.
        if (_char.isGrounded) // �������� �� ��, ��������� �� �������� �� �����
        {
            direction = new Vector3(x, 0f, z); // ������� ���������� ������ ��������, ���������� � ����������

            if (!Input.GetButton("Run"))
            {
                _anim.SetFloat("Vertical", x);
            }
            _anim.SetFloat("Horizontal", z);// ������ �������� ��� ���������� ���������. ����� ������� �������� �� ������� �������� �������� � ����
            direction = transform.TransformDirection(direction) * moveSpeed; // ������ ����������� �������� ��������� � �������� ��� �� �������� ������������
            if (Input.GetButton("Jump")) // ���������, �� ���������� �� ������ ������
            {
                direction.y = jumpSpeed; // ���������� ��������� ����� �� ��� y
            }

            if (Input.GetButton("Run") && z > 0)
            {
                moveSpeed = runSpeed;
                _anim.SetFloat("Horizontal", Mathf.Clamp(z + 1, 0f, 2f));
            }
            if (!Input.GetButton("Run"))
            {
                moveSpeed = speed;
            }

        }

        direction.y -= gravity * Time.deltaTime; // ���������� ��������� ��������� �� ����� � ������������ ����� ������. �������� + �� - ��� ������� ������� �� ��������
        _char.Move(direction * Time.deltaTime); // ���������� ��������� � ����������, �������� ��������� � ������ � ����������. ����� ���������� ��� ����� �������� ��������.
    }


    private void GetRotate()
    {

        PlayerRotate.y += MouseX; // ������� ��������� �� ��� Y. Y �.�. ������ ������ ��� ���������� ������� ������-����� ��� �������

        ChestRotate.z -= MouseY; // ������� ��������� �� ��� Z. Z �.�. Blender � Unity ����� ������ ����������� ����.
        ChestRotate.z = (Mathf.Clamp(ChestRotate.z, -80f, 30f)); // ������������ �������� �� ���, ����� �� ������ 360

        transform.localEulerAngles = PlayerRotate; // ����������� ������� �������, �� ������� ����� ������ ������ ������

        Chest.transform.localEulerAngles = ChestRotate; // ����������� ������� �������, ������� �� �������� � Transform, � ������ ������ - �� �����
    }
}
