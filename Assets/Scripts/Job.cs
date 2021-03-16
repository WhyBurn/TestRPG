using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    private JobData job;
    private int exp;

    public Job(JobData d)
    {
        job = d;
        exp = 0;
    }
    public Job(JobData d, int e)
    {
        job = d;
        exp = e;
    }

    public JobData Info
    {
        get { return (job); }
    }
    public int Exp
    {
        get { return (exp); }
    }
    public int Level
    {
        get
        {
            int level = 0;
            while(job.expIntercept + (job.expSlope * level) < exp)
            {
                ++level;
            }
            return (level);
        }
    }
}
