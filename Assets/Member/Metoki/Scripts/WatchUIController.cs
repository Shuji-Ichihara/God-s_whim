using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchUIController : MonoBehaviour
{
    //時計の貼り
    [SerializeField]
    private Transform _hourHand;

    //一周にかかる時間
    [SerializeField]
    private float _routationDuration;
    //記録する時間
    [SerializeField]
    private float _recordDuration;

    private List<ClockHnadState> stateHistry = new List<ClockHnadState>();

    //巻き戻し中かどうか
    private bool _isRewdining = false;

    //回転の経過時間
    [SerializeField]
    private float _elppsedRotateionTime;


    //記録用の構造体
    private struct ClockHnadState
    {
        public Quaternion _rotation;

        public ClockHnadState(Quaternion rot)
        {
            _rotation = rot;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //最初針の位置を12時に固定
        _hourHand.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _isRewdining = true;
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            _isRewdining = false;
        }

        if(_isRewdining)
        {
            Rwind();
        }
        else
        {
            Record();
            RotateHand();
        }
    }

    void RotateHand()
    {
        float elpsedTime = 0;
        while (elpsedTime < _routationDuration)
        {
            //経過時間に基づいて針を回転させる
            float angle = (elpsedTime /  _routationDuration) * 360f;
            _hourHand.localRotation = Quaternion.Euler(0, 0, -angle);

            elpsedTime += Time.deltaTime;
            //yield return null;
       }
        //5秒後に時計の針を一周させて終了
        _hourHand.localRotation = Quaternion.Euler(0, 0, -360f);
    }

    void Rwind()
    {

    }

    void Record()
    {

    }
}
