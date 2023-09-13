using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SoundWave : MonoBehaviour
{
    private const int SAMPLE_SIZE = 1024;

    public float rmsValue;
    public float dbValue;
    public float pitchValue;
    public float maxvisualScale = 25.0f;
    public float visualModfier = 50.0f;
    public float smoothSpeed = 10.0f;
    public float keepPercentage = 0.5f;
    [SerializeField]GameObject[] gameObjects;
    [SerializeField] GameObject strpos;


    [SerializeField]private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampeRate;

    private Transform[] visualList;
    private float[] visualScale;
    private int amnVisual = 25;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
        samples = new float[1024];
        spectrum = new float[1024];
        sampeRate = AudioSettings.outputSampleRate;
        SpawnLine();
    }
    private void SpawnLine()
    {
        visualScale = new float[amnVisual];
        visualList = new Transform[amnVisual];
        int j = 0;

        for (int i = 0; i < amnVisual; i++)
        {
            if (j == gameObjects.Length) j = 0;
            GameObject go = GameObject.Instantiate(gameObjects[j], strpos.transform.position, Quaternion.identity); // ‚±‚±‚ð•ÏX
            go.transform.SetParent(transform, false);
            visualList[i] = go.transform;
            visualList[i].position = strpos.transform.position + Vector3.right * i;
            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound();
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)(SAMPLE_SIZE * keepPercentage) / amnVisual;

        while(visualIndex < amnVisual)
        {
            int j = 0;
            float sum = 0;
            while(j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModfier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if (visualScale[visualIndex] < scaleY)
                visualScale[visualIndex] = scaleY;

            if (visualScale[visualIndex] > maxvisualScale)
                visualScale[visualIndex] = maxvisualScale;

            visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
            visualIndex++; 
        }
    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        // get RMS

        int i = 0;
        float sum = 0;

        for(; i < SAMPLE_SIZE;i++)
        {
            sum = samples[i] * samples[i];
        }

        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //get db

        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //get sound sp

        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //find pitch

        //float maxV = 0;
        //var maxN = 0;

        //for(i = 0; i< SAMPLE_SIZE; i++)
        //{
        //    if (!(spectrum[i] < maxV) || !(spectrum[i] > 0.0f))
        //        continue;

        //    maxV = spectrum[i];
        //    maxN = i;
        //}

        //float freqN = maxN;
        //if(maxN > 0 && maxN < SAMPLE_SIZE -1)
        //{
        //    var DL = spectrum[maxN - 1] / spectrum[maxN];
        //    var DR = spectrum[maxN + 1] / spectrum[maxN];
        //    freqN += 0.5f * (DR * DR - DL * DL);
        //}
        //pitchValue = freqN * (sampeRate / 2) / SAMPLE_SIZE;
    }
}
