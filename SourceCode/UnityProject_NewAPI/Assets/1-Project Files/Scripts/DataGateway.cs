using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DataGateway : MonoBehaviour
{

    private PythonClient _pythonClient;
    public PythonClient PythonClient { get => _pythonClient; }

    [SerializeField]
    private TestingManager testingManager;

    // Start is called before the first frame update
    void Start()
    {
        _pythonClient = new PythonClient();
    }

    public void OnExcerciseRecognized(string exercise)
    {
        TrainingType trainingType = (TrainingType)Enum.Parse(typeof(TrainingType), exercise);
        testingManager.FillRecognizedExcerciseOutputInput(trainingType);
    }

    public void OnModelListReceived(string modelList)
    {
        testingManager.SetModelsForDropdown(new List<string>(modelList.Split(',')));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        _pythonClient.Stop();
    }
}
