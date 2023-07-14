using UnityEngine;

public class StandartPlayer : MonoBehaviour, IMiner
{
    [SerializeField]
    private LayerMask layer;

    [SerializeField]
    public float CurrentResources = 0;

    [SerializeField]
    private Tool tool;

    public GameObject GetPlayer()
    {
        return gameObject;
    }

    public void Mine()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Minerals minerals;

            if ((minerals = hit.transform.GetComponent<Minerals>()) is not null)
            {
                minerals.Trigger(this);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Mine();
    }

    public void DistributeMineral(Minerals minerals, float mineralCount)
    {
        CurrentResources += mineralCount;
    }

    public Tool GetTool()
    {
        return tool;
    }
}