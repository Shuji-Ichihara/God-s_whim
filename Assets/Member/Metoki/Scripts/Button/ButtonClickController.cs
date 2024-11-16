using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonClickController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //ボタン
    [SerializeField]
    private Image _buttonImage;

    //ボタンの従来のカラー
    private Color _originalColor;
    //マウスが重なった際のカラー
    [SerializeField]
    private float _darkentAmount;
    [SerializeField]
    private float _hideDuration;
    // Start is called before the first frame update
    void Start()
    {
        //ボタンの元の色を保存
        _buttonImage.GetComponent<Image>();
        if(_buttonImage != null )
        {
            _originalColor = _buttonImage.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //マウスが重なったとき
    public void OnPointerEnter(PointerEventData eventData)
    {
        if( _buttonImage != null )
        {
            Color darkentColor = new Color(_originalColor.r * _darkentAmount,
                                           _originalColor.g * _darkentAmount,
                                           _originalColor.b * _darkentAmount,
                                           _originalColor.a); //カラーを暗く 
            _buttonImage.color = darkentColor;
        }
    }
    //マウスが離れたとき
    public void OnPointerExit(PointerEventData eventData)
    {
        if( _buttonImage != null )
        {
            _buttonImage.color = _originalColor;//もとの色に戻す
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_buttonImage != null )
        {
            StartCoroutine(HideAndResotreImage());
        }
    }
    IEnumerator HideAndResotreImage()
    {
        _buttonImage.enabled = false;
        yield return new WaitForSeconds( _hideDuration );
        _buttonImage.enabled = true;
    }
}
