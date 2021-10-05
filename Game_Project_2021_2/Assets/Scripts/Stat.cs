using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Scriptable Object Asset/Stat")]
public class Stat : ScriptableObject
{
    public int _health;
    public int _TPRegeneration;
    public int _defense;
    public int _damage;
    public float _moveSpeed = 4.5f;
    public int _needTP = 1000;
    public float _range;
    public float _AttackdelayTime;
}
