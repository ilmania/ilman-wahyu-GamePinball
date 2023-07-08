using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControler : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    private bool isOn;
    private Renderer renderer;
    private SwitchState state;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other = bola)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            SwitchOn();
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            SwitchOff();
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            SwitchOn();
            yield return new WaitForSeconds(0.5f);
            SwitchOff();
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private void SwitchOn()
    {
        renderer.material.color = Color.yellow;
        renderer.material.EnableKeyword("_EMISSION");
        renderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
    }

    private void SwitchOff()
    {
        renderer.material.color = Color.grey;
        renderer.material.DisableKeyword("_EMISSION");
        renderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
    }
}
