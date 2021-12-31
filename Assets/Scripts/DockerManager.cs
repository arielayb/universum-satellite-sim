using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class DockerManager : MonoBehaviour
{
    private ProcessStartInfo dockerInfo_;
    private static int numOutputLines = 0;

    // Start is called before the first frame update
    void Start()
    {
        dockerInfo_.CreateNoWindow = true;
        dockerInfo_.UseShellExecute = false;
        dockerInfo_.RedirectStandardOutput = true;
        dockerInfo_.RedirectStandardError = true;
    }

    public void GetSatelliteCoordinates(object sender, DataReceivedEventArgs e) {
        if () { 
        
        }
    
    }


    // Update is called once per frame
    void Update()
    {
        Process process = new Process();
        process.StartInfo = dockerInfo_;

        process.OutputDataReceived += new DataReceivedEventHandler(GetSatelliteCoordinates);
        process.ErrorDataReceived += new DataReceivedEventHandler(GetSatelliteCoordinates);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit(1200000);
        if (!process.HasExited)
        {
            process.Kill();
        }

        int exitCode = process.ExitCode;
        process.Close();

    }
}
