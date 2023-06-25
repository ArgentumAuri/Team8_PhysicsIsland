using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Управление анимацией и персонажем")]
    public Animator _anim; // Получаем доступ к компоненту, отвечающему за анимацию
    public CharacterController _char; // Получаем доступ к компоненту, отвечающему за передвижение персонажа
    Transform PlayerTransform;

    [Header("Звуки движеня")]
    public AudioSource _StepSoundController;
    public AudioClip GrassStep;
    public AudioClip StoneStep;

    [Header("Векторы движения")]
    Vector3 direction; // Данный вектор будет отвечать за то, куда будет идти персонаж
    Vector3 PlayerRotate; // Данный вектор будет отвечать за поворот персонажа по оси Х
    Vector3 ChestRotate; // Данный вектор будет отвечать за поворот груди по оси Y. Необходим для того, чтобы игрок смотрел вверх

    [Header("Объекты для трансформации")]
    public Transform Chest; // Данный трансформ необходим для поворота груди.

    [Header("Переменные для скорости персонажа")]
    public float speed = 7f;
    public float runSpeed = 14f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    public float moveSpeed;

    [Header("Переменные для параметров управления мышью")]
    public float MouseX;
    public float MouseY;
    private float mouseSensetivity = 300f;
    //public float currentSense = 300f;



    [Header("Ладонь правой руки. Место для спавна оружия")]
    public float aiming;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Блокировка поворота курсора
        _anim = GetComponent<Animator>(); // Привязываем аниматор к переменной, чтобы было удобнее его использовать
        _char = GetComponent<CharacterController>(); // То же самое с CharacterControll
        moveSpeed = speed;

    }



    void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        GetRotate(); // Добавляем метод в LateUpdate. В этом методе события выполняются после Update. Для нас так тупо удобнее. Можно было и в Update закинуть
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.layer);
        _StepSoundController.clip = StoneStep;
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log(collision.gameObject.layer);
        _StepSoundController.clip = GrassStep;
    }

    private void GetInput() // Здесь будет все, что связанно с воодом данных с клавиатуры и мыши
    {
        float x = Input.GetAxis("Horizontal"); // Объявляем две переменные для передвижения по оси X. Используем оси для более гибкой настройки управления
        float z = Input.GetAxis("Vertical");// Объявляем две переменные для передвижения по оси Z. Используем оси для более гибкой настройки управления
        MouseX = Mathf.Clamp(Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime, -80f, 80f); // Задаем значение для оси Х мыши.
        MouseY = Mathf.Clamp(Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime, -80f, 80f); // Задаем значение для оси Y мыши.
        if (_char.isGrounded) // Проверка на то, находится ли персонаж на земле
        {
            direction = new Vector3(x, 0f, z); // Вектору напрвления задаем значения, полученние с клавиатуры
            if (!Input.GetButton("Run"))
            {
                _anim.SetFloat("Horizontal", Mathf.Abs(x));
                
            }
            _anim.SetFloat("Horizontal", Mathf.Abs(z));// Задаем значение для переменной аниматора. Таким образом персонаж из стоячей анимации перейдет к шагу
            StepsSoundPlay(x, _char.isGrounded, z);

            direction = transform.TransformDirection(direction) * moveSpeed; // Задаем направление движению персонажа и умножаем его на скорость передвижения
            if (Input.GetButton("Jump")) // Проверяем, не нажималась ли кнопка прыжка
            {
                direction.y = jumpSpeed; // Устремляем персонажа вверх по оси y
                _StepSoundController.Stop();
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
        direction.y -= gravity * Time.deltaTime; // Заставляет персонажа двигаться по земле и приземляться после прыжка. Поменять + на - для прикола никогда не помешает
        _char.Move(direction * Time.deltaTime); // Устремляем персонажа в координаты, заданные скоростью и вводом с калвиатуры. Время необходимо для более плавного действия.
    }


    private void GetRotate()
    {

        PlayerRotate.y += MouseX; // Поворот персонажа по оси Y. Y т.к. именно вокруг нее происходит поворот вправо-влево без наклона

        ChestRotate.z -= MouseY; // Поворот персонажа по оси Z. Z т.к. Blender и Unity имеют разные направления осей.
        ChestRotate.z = (Mathf.Clamp(ChestRotate.z, -80f, 50f)); // Ограничиваем вращение по оси, чтобы не делать 360

        transform.localEulerAngles = PlayerRotate; // Присваиваем поворот объекту, на котором висит данный скрипт скрипт

        Chest.transform.localEulerAngles = ChestRotate; // Присваиваем поворот объекту, который мы добавили в Transform, в данном случае - на грудь
    }

    private void StepsSoundPlay(float x, bool flag, float z)
    {
        if (((Mathf.Abs(z) >= 0.35f) || (Mathf.Abs(x) >= 0.35f)) && flag)
        {
            if (_StepSoundController.isPlaying || !flag) return;
            _StepSoundController.Play();
        }
        else
        {
            _StepSoundController.Stop();
        }
    }
}
