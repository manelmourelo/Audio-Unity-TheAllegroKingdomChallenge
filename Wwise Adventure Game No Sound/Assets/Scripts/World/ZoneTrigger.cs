////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    //public AK.Wwise.State MusicState;
    public bool isSafeZone = false;

    public enum MusicState
    {
        NONE,
        CAVE,
        DESERT,
        FORGE,
        DUNGEON,
        VILLAGE,
        MAGICHOUSE,
        WOODLANDS,
        PINEFOREST
    }

    public MusicState musicState = MusicState.VILLAGE;

    private void DetermineZone(string zone_name)
    {
        if (zone_name == "MusicRegion_Cave")
            musicState = MusicState.CAVE;
        else if (zone_name == "MusicRegion_Desert")
            musicState = MusicState.DESERT;
        else if (zone_name == "MusicRegion_Forge")
            musicState = MusicState.FORGE;
        else if (zone_name == "MusicRegion_Dungeon")
            musicState = MusicState.DUNGEON;
        else if (zone_name == "MusicRegion_Village")
            musicState = MusicState.VILLAGE;
        else if (zone_name == "MusicRegion_WwizardMagicHouse")
            musicState = MusicState.MAGICHOUSE;
        else if (zone_name == "MusicRegion_Woodlands")
            musicState = MusicState.WOODLANDS;
        else if (zone_name == "MusicRegion_PineForest")
            musicState = MusicState.PINEFOREST;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            DetermineZone(gameObject.name);
            GameManager.Instance.EnterZone(this);
        }
        else
        {
            if (isSafeZone && col.gameObject.layer == LayerMask.NameToLayer("Agent"))
            {
                Protector(col);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.LeaveZone(this);
        }
    }

    void Protector(Collider col)
    {
        Creature C = col.gameObject.GetComponent<Creature>();

        if (C != null)
        {
            if (!C.isFriendly && C is IDamageable)
            {
                GameManager.DamageObject(col.gameObject, new Attack(1000f));

                WwizardProtector.SetBeam(C.gameObject);
            }
        }
    }
}
