﻿using UnityEngine;
using System.Collections;
using System;

public class DistanceManager : MonoBehaviour
{

    static public double Distance(double lat1, double lon1, double lat2, double lon2, char unit)
    {

        double theta = lon1 - lon2;
        double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2))
         * Math.Cos(deg2rad(theta));
        dist = Math.Acos(dist);
        dist = rad2deg(dist);
        dist = dist * 60 * 1.1515;
        if (unit == 'K')
        {
            dist = dist * 1.609344;
        }
        else if (unit == 'N')
        {
            dist = dist * 0.8684;
        }
        return (dist);
    }

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //::  This function converts decimal degrees to radians             :::
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    static private double deg2rad(double deg)
    {
        return (deg * Math.PI / 180.0);
    }

    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    //::  This function converts radians to decimal degrees             :::
    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    static private double rad2deg(double rad)
    {
        return (rad / Math.PI * 180.0);
    }

    /*
    Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "M"));
    Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "K"));
    Console.WriteLine(distance(32.9697, -96.80322, 29.46786, -98.53506, "N"));
    */
}
