using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.interfaces;

public class Bullet : Ammunition
{
    #region Serialize variable
    [SerializeField] private float _timeToDestruct = 10f;
    [SerializeField] private float _damage = 20;
    [SerializeField] private float _mass = 0.1f;
    #endregion

    private float _curentDamage;

    private void Awake()
    {
        Destroy(gameObject, _timeToDestruct);
        _curentDamage = _damage;
        gameObject.GetComponent<Rigidbody>().mass = _mass;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet") return;
        SetDamage(collision.gameObject.GetComponent<ISetDamage>());
        Destroy(gameObject);
    }

    public void SetDamage( ISetDamage obj)
    {
        if (obj != null) obj.ApplyDamage(_curentDamage);
    }
}
