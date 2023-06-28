using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIWriter : MonoBehaviour
{
    public Text _text;
    public TMP_Text _tmpProText;
    string writer;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>()!;
        _tmpProText = GetComponent<TMP_Text>()!;

        if (_text != null)
        {
            writer = _text.text;
            _text.text = "";

            StartCoroutine("TypeWriterText");
        }

        if (_tmpProText != null)
        {
            writer = _tmpProText.text;
            _tmpProText.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }
    public void typeText(Text textbox,string text)
    {
        StopCoroutine("TypeWriterText");
        writer = "";
        _text = textbox;
        if (_text != null)
        {
            writer = text;
            _text.text = "";
            Debug.Log(writer);
            StartCoroutine("TypeWriterText");
        }
    }
    public void typeTMPText(TMP_Text textbox, string text)
    {
        StopCoroutine("TypeWriterTMP");
        writer = "";
        _tmpProText = textbox;
        if (_tmpProText != null)
        {
            writer = text;
            _tmpProText.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }
    public IEnumerator TypeWriterText()
    {
        _text.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_text.text.Length > 0)
            {
                _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
            }
            _text.text += c;
            _text.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
        }
    }

    public IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
}