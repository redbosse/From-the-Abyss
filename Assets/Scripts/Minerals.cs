using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EventBusSystem;

public interface IMineralDistributor : IGlobalSubscriber
{
    public void Distribute(Minerals mineral, IMiner miner);
}

public class Minerals : MonoBehaviour
{
    [SerializeField]
    private float MineralValue = 10;

    public void TakeMineral(float count)
    {
        MineralValue -= count;

        if (MineralValue < 0)
            Destroy(gameObject);
    }

    public void Trigger(IMiner miner)
    {
        EventBus.RaiseEvent<IMineralDistributor>(h => h.Distribute(this, miner));
    }
}