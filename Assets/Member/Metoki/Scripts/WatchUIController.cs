using System.Collections;
using UnityEngine;

public class WatchUIController : MonoBehaviour
{
    //時計の貼り
    [SerializeField]
    private Transform _hourHand;

    //一周にかかる時間
    [SerializeField]
    private float _routationDuration;
    // Start is called before the first frame update
    void Start()
    {
        //最初針の位置を12時に固定
        _hourHand.localRotation = Quaternion.Euler(0, 0, 0);
        //一周させる処理開始
        StartCoroutine(RotateHand());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RotateHand()
    {
        float elpsedTime = 0;
        while (elpsedTime < _routationDuration)
        {
            //経過時間に基づいて針を回転させる
            float angle = (elpsedTime /  _routationDuration) * 360f;
            _hourHand.localRotation = Quaternion.Euler(0, 0, -angle);

            elpsedTime += Time.deltaTime;
            yield return null;
        }
        //5秒後に時計の針を一周させて終了
        _hourHand.localRotation = Quaternion.Euler(0, 0, -360f);
    }
}
