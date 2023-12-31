using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamouflageScript : MonoBehaviour
{
    public string temporaryLayer = "Phantom";
    public InputAction camouflageAction;

    public float timeToLive = 5f;
    public float timeToRecharge = 5f;
    private float timeToRechargeLeft = 0f;
    public bool isCamouflaged = false;
    private bool isRecharging = false;
    private int originalLayer;

    ShockWaveManager shockWaveManager;
    public SpriteRenderer spriteRenderer;

    public bool CamouflagedState()
    {
        return isCamouflaged;
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        shockWaveManager = ShockWaveManager.Instance;

        originalLayer = gameObject.layer;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set up the Input System action
        camouflageAction = new InputAction(binding: "<Gamepad>/buttonSouth"); // Customize the binding according to your needs
        camouflageAction.performed += ctx => OnCamouflageAction();
        camouflageAction.Enable();
    }

    private void OnDestroy()
    {
        // Disable the Input System action when the script is destroyed
        camouflageAction.Disable();
    }

    private void OnCamouflageAction()
    {
        if (!isCamouflaged && !isRecharging)
        {
            StartCoroutine(ActivateCamouflage());
        }
    }

    private void Update()
    {
        if (isRecharging)
        {
            timeToRechargeLeft -= Time.deltaTime;
            if (timeToRechargeLeft <= 0)
            {
                timeToRechargeLeft = 0;
                isRecharging = false;
            }
        }
        // No need to check for camouflage key in Update
    }

    private IEnumerator ActivateCamouflage()
    {
        isCamouflaged = true;
        StartCoroutine(DisableCollisions());
        shockWaveManager.CallShockWave();
        yield return new WaitForSeconds(timeToLive);

        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        gameObject.layer = originalLayer;
        isCamouflaged = false;
        isRecharging = true;
        StartCoroutine(Recharge());
    }

    private IEnumerator DisableCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer(temporaryLayer);
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(timeToLive);
    }

    private IEnumerator Recharge()
    {
        timeToRechargeLeft = timeToRecharge;
        if (isRecharging)
        {
            yield break;
        }
        yield return new WaitForSeconds(timeToRecharge);
        isRecharging = false;
    }
}
