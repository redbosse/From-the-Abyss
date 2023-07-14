using UnityEngine;

public interface IMiner
{
    public void Mine();

    public void DistributeMineral(Minerals minerals, float mineralCount);

    public GameObject GetPlayer();

    public Tool GetTool();
}