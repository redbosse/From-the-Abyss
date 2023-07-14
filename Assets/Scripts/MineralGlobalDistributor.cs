using UnityEngine;

public class MineralGlobalDistributor : MonoBehaviour, IMineralDistributor
{
    private void OnEnable()
    {
        EventBusSystem.EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBusSystem.EventBus.Unsubscribe(this);
    }

    public void Distribute(Minerals mineral, IMiner miner)
    {
        mineral.TakeMineral(miner.GetTool().mineRate);
        miner.DistributeMineral(mineral, miner.GetTool().mineRate);
    }
}