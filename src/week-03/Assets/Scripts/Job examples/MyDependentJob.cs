using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public class MyDependentJob : MonoBehaviour
{
    // Create a native array of a single float to store the result. This example waits for the job to complete.
    NativeArray<float> result;
    // Create a JobHandle to access the results 
    JobHandle secondHandle;

    // Set up the first job
    public struct MyJob : IJob
    {
        public float a;
        public float b;
        public NativeArray<float> result;

        public void Execute()
        {
            result[0] = a + b;
        }
    }

    // Set up the second job, which adds one to a value
    public struct AddOneJob : IJob
    {
        public NativeArray<float> result;

        public void Execute()
        {
            result[0] = result[0] + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set up the job data for the first job
        result = new NativeArray<float>(1, Allocator.TempJob);

        MyJob jobData = new MyJob
        {
            a = 10,
            b = 10,
            result = result
        };

        // Schedule the first job
        JobHandle firstHandle = jobData.Schedule();

        // Setup the data for the second job
        AddOneJob incJobData = new AddOneJob
        {
            result = result
        };

        // Schedule the second job
        secondHandle = incJobData.Schedule(firstHandle);
    }

    private void LateUpdate()
    {
        // Sometime later in the frame, wait for the job to complete before accessing the results.
        secondHandle.Complete();

        // All copies of the NativeArray point to the same memory, you can access the result in "your" copy of the NativeArray
        // float aPlusBPlusOne = result[0];

        // Free the memory allocated by the result array
        result.Dispose();
    }

}