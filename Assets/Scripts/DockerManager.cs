using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using System.Text;

public class DockerManager : MonoBehaviour
{
    private ProcessStartInfo dockerInfo_;
    private static int numOutputLines = 0;
    private static StringBuilder sortOutput = null;

    // Start is called before the first frame update
    void Start()
    {
        dockerInfo_ = new ProcessStartInfo("cmd", "/c docker start gnss-sdr");
        //dockerInfo_.Arguments = "docker run -a stdin -a stdout -it gnss-sdr";
        dockerInfo_.CreateNoWindow = true;
        dockerInfo_.UseShellExecute = false;
        dockerInfo_.RedirectStandardOutput = true;
        dockerInfo_.RedirectStandardError = true;
        UnityEngine.Debug.Log("docker loaded");

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

    public void GetSatelliteCoordinates(object sender, 
                                        DataReceivedEventArgs outLine) {
        // Collect the sort command output.
        if (!String.IsNullOrEmpty(outLine.Data))
        {
            UnityEngine.Debug.Log(numOutputLines);
            numOutputLines++;

            // Add the text to the collected output.
            sortOutput.Append(Environment.NewLine +
                $"[{numOutputLines}] - {outLine.Data}");
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
