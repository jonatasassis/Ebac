
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class PlayerJumpState : PlayerBaseState
{
    public GameObject player;
    public bool canJump = false;
    public SFXType sfxType;


    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("entrei no jump state");
        canJump = true;
    }
    public override void UpdateState(PlayerStateManager player)
    {
        if (canJump == true)
        {
            PlaySFX();
            player.transform.DOMoveY(12, 2);
            canJump = false;
        }
        else if (canJump == false)
        {
            player.TrocarState(player.idleState);
        }

    }
    private void PlaySFX()
    {
        SFXPool.Instance.Play(sfxType);
    }
}
