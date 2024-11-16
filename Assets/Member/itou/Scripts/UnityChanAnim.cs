using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanAnim : MonoBehaviour
{

    [SerializeField]
    private Animator _unityChananimator;
    [SerializeField]
    private GameObject _DamageEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        _unityChananimator.SetBool("Damage", true);
        yield return new WaitForSeconds(1);
        Instantiate(_DamageEffect,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
