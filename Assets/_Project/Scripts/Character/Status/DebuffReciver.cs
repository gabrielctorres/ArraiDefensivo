using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffReciver : MonoBehaviour
{
    public List<SlotDebuff> slots = new List<SlotDebuff>();
    private Enemie entity;

    private void Start()
    {

        entity = GetComponent<Enemie>();
    }
    public void AddEffect(Debuff _effect)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].effect == null)
            {
                slots[i].effect = _effect;
                break;
            }
        }
    }
    public void RemoveEffect(SlotDebuff _slot)
    {
        _slot.effect.Remove(entity);
        ResetSlot(_slot);
    }
    private void Update()
    {
        foreach (SlotDebuff slot in slots)
        {
            StartCoroutine(HandleEffect(slot));
        }
    }
    public IEnumerator HandleEffect(SlotDebuff _slot)
    {
        if (_slot.effect != null)
        {
            Debuff debuff = _slot.effect;
            _slot.currentTime += Time.deltaTime;

            if (_slot.currentTime >= _slot.effect.cooldown)
            {
                RemoveEffect(_slot);
            }

            if (_slot.currentTime > _slot.nextTickSpeed)
            {
                _slot.nextTickSpeed += _slot.effect.tickSpeed;
                _slot.effect.Apply(entity);
                InstanteVisualEffect(_slot, _slot.effect.visualEffect, _slot.effect.cooldown);
            }
            yield return null;
        }

    }
    public void InstanteVisualEffect(SlotDebuff _slot, GameObject _visualEffect, float _cooldown)
    {
        if (_slot.effect.visualEffect == null) return;

        if (_slot.instanceVisualEffect == null)
            _slot.instanceVisualEffect = Instantiate(_visualEffect, transform.position, Quaternion.identity, transform);
        else
            Destroy(_slot.instanceVisualEffect, _slot.effect.cooldown);
    }
    protected void ResetSlot(SlotDebuff _slot)
    {
        _slot.effect = null;
        _slot.currentTime = 0;
        _slot.nextTickSpeed = 0;
    }
}
[System.Serializable]
public class SlotDebuff
{
    public Debuff effect;
    public GameObject instanceVisualEffect;
    public float currentTime;
    public float nextTickSpeed;
}