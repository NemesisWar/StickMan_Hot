using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeItem : PlayerControl
{
    [SerializeField] private ItemTaked _itemTaked;
    protected override void Start()
    {
        _playerInput.Player.TakeItem.performed += ctx => TryTakeItem();
    }

    private void TryTakeItem()
    {
        _itemTaked.TryTake();
    }
}
