using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeLifeMax(float lifeMax) {
        slider.maxValue = lifeMax;
    }

    public void ChangeLifeCurrent(float lifeAmount)
    {
        slider.value = lifeAmount;
    }

    public void InitializerLifeBar(float lifeAmount)
    {
        ChangeLifeMax(lifeAmount);
        ChangeLifeCurrent(lifeAmount);
    }
}
