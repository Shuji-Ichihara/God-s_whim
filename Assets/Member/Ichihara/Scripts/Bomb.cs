using UnityEngine;

public class Bomb : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
    {// 破壊可能オブジェクトの場合は自身と対象のオブジェクトを破棄する
        if (other.gameObject.name.Contains("Breakable"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // プレイヤーに当たった場合はゲームオーバー
        var unityChan = other.gameObject.GetComponent<UnityChanAnim>();
        if (unityChan != null)
        {
            Destroy(gameObject);
            StartCoroutine(unityChan.Damage());
        }
    }
}
