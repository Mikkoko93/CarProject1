﻿using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;




namespace CarProject
{
 
    #region
    class Car
    {
        //car class and its methods
        public int Speed(int vSpeed)
        {
            return vSpeed;
        }

        public int Direction(int vDirection)
        {
            return vDirection;
        }
        public bool Engine(bool vEngine)
        {
            return vEngine;
        }
    }
    #endregion
    class Program
    {
        public static int cSpeed { get; set; }
        public static int cDirection { get; set; }

        public static int rSpeed { get; set; }

        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            string val;
            Car myCar = new Car();
            // int cSpeed = 0;
            // int cDirection = 0;
            //int rSpeed = 0;
            bool cEngine = false;

            //timer
            #region
            System.Timers.Timer newTimer = new System.Timers.Timer();
            newTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            newTimer.Interval = 2000;


            /*while (Console.Read() != 'q')
            {
                ;    // we can write anything here if we want, leaving this part blank won’t bother the code execution.
            }*/
            #endregion

            //ask user about starting engine and make sure answer is "yes"
            Console.WriteLine("Start your car? yes/no");
            val = Console.ReadLine();
            if (val == "yes")
            {
                cEngine = myCar.Engine(true);
                Console.WriteLine("Car throttle: W \n Car break: S \n Turn left: A \n Turn right: D \n Shut down Engine: T");
                cSpeed = myCar.Speed(0);
                cDirection = myCar.Direction(0);
            }
            else
                // if engine is not started on first go, it will shut down the program.
                Console.WriteLine("Shutting down");
            //engine must be on before moving
            while (cEngine == true)
            {
                //start timer when engine is on
                newTimer.Start();
                //user input and car moving after
                #region
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.W:
                        //speed slowing down when reversed
                        if (cSpeed < 0)
                        {
                            cSpeed = myCar.Speed(cSpeed + 5);
                            rSpeed = cSpeed * -1;
                            //Console.WriteLine("slowing down reverse speed to " + rSpeed + "km/h");
                            break;
                        }
                        //normal thrust
                        else
                        { 
                        cSpeed = myCar.Speed(cSpeed + 5);
                        //Console.WriteLine("speeding up: " + cSpeed + "Km/h");
                        break;
                        }
                    case ConsoleKey.S:
                        //reversing shown as km/h and not -km/h
                        if (cSpeed <= 0)
                        {
                            cSpeed = myCar.Speed(cSpeed - 5);
                            rSpeed = cSpeed * -1;
                            //Console.WriteLine("reversing at " + rSpeed + "km/h");
                            break;
                        }
                        //normal slowing down if cspeed is on positive
                        else
                        {
                            cSpeed = myCar.Speed(cSpeed - 5);
                            //Console.WriteLine("Slowing down: " + cSpeed + "Km/h");
                            break;
                        }

                    case ConsoleKey.A:
                        //turning left 15 degrees on a button press
                        if (cSpeed != 0)
                        {
                            cDirection = myCar.Direction(cDirection - 15);
                            //Console.WriteLine("Turning left " + cDirection + "°");
                            break;
                        }
                        //car turning disabled when speed is at 0
                        else
                            Console.WriteLine("Car doesnt turn at " + cSpeed + "km/h");
                        break;
                    case ConsoleKey.D:
                        //turning right 15 degrees on a button press
                        if (cSpeed != 0)
                        {
                            cDirection = myCar.Direction(cDirection + 15);
                            //Console.WriteLine("Turning right " + cDirection + "°");
                            break;
                        }
                        //car turning disabled when speed is at 0
                        else
                            Console.WriteLine("Car doesnt turn at " + cSpeed + "km/h");
                        break;
                    case ConsoleKey.T:
                        //engine shutdon applicable if speed is below 20km/h
                        if(cSpeed < 21)
                        {
                            cEngine = myCar.Engine(false);
                            Console.WriteLine("Engine Offline");
                        }
                        return;

                }
                #endregion

                //there is only 360 degrees in a full circle.
                if (cDirection>=360 || cDirection <= -360)
                {
                    cDirection = 0;
                }


            }


        }
        public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            if (cSpeed < 0)
            {
                Console.WriteLine("Current Reverse Speed: " + rSpeed.ToString() + " km/h and direction is: " + cDirection.ToString() + "°");
            }
            else
                Console.WriteLine("Current Speed: " + cSpeed.ToString() + " km/h and direction is: " + cDirection.ToString() + "°");

        }
    }
}
