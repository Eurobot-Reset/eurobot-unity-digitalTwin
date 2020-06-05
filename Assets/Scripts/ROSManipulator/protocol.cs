using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protocol : MonoBehaviour
{
    // RACER
    public static int GRIPPER_1 = 1;
    public static int GRIPPER_2 = 2;
    public static int GRIPPER_12 = 3;
    public static int GRIPPER_3 = 4;
    public static int GRIPPER_13 = 5;
    public static int GRIPPER_23 = 6;
    public static int GRIPPER_123 = 7;

    public static int GRIPPER_DOWN = 0x10;
    public static int GRIPPER_HIGH_UP = 0x11;
    public static int GRIPPER_LOW_UP = 0x12;

    public static int GRIPPER_FOR_WINDSOCKS = 0x32;
    public static int GET_BAROMETER_DATA = 0x15;

    public static int PUMP_1_SUCK_ON = 0x16;
    public static int PUMP_1_SUCK_OFF = 0x17;
    public static int PUMP_2_SUCK_ON = 0x18;
    public static int PUMP_2_SUCK_OFF = 0x19;
    public static int PUMP_3_SUCK_ON = 0x1A;
    public static int PUMP_3_SUCK_OFF = 0x1B;

    // IF WE LOOK FROM TOP TO BOTTOM THE GRIPPER'S LOCATION IS IN FRONT OF THE ROBOT'S BODY
    // SCHEME:
    //        ()(L)()1()(R)()
    //         ()         ()
    //          ()       ()
    //           ()     ()
    //            ()   ()
    //              ()()
    //

    public static int VALVE_1_LEFT_OPEN = 0x20;
    public static int VALVE_1_LEFT_CLOSE = 0x21;
    public static int VALVE_1_RIGHT_OPEN = 0x22;
    public static int VALVE_1_RIGHT_CLOSE = 0x23;

    public static int VALVE_2_LEFT_OPEN = 0x26;
    public static int VALVE_2_LEFT_CLOSE = 0x27;
    public static int VALVE_2_RIGHT_OPEN = 0x28;
    public static int VALVE_2_RIGHT_CLOSE = 0x29;

    public static int VALVE_3_LEFT_OPEN = 0x2C;
    public static int VALVE_3_LEFT_CLOSE = 0x2D;
    public static int VALVE_3_RIGHT_OPEN = 0x2E;
    public static int VALVE_3_RIGHT_CLOSE = 0x2F;

    // FATBOY

    public static int GET_PAW_DATA = 0x63;
    public static int STEPPER_IS_RUNNING = 0x62;
    
    public static int ARM_UP = 0x10;
    public static int ARM_DOWN = 0x11;
    public static int ARM_FLOOR = 0x1A;
    public static int ARM_MEDIUM = 0x1B;
    public static int PAWS_OPEN = 0x12;
    public static int PAWS_CLOSE = 0x13;
    public static int DOOR1_OPEN_X = 0x14;
    public static int DOOR1_OPEN_Y = 0x18;
    public static int DOOR2_OPEN_X = 0x15;
    public static int DOOR2_OPEN_Y = 0x19;
    public static int DOOR1_CLOSE = 0x16;
    public static int DOOR2_CLOSE = 0x17;

    public static int PAW1_OPEN = 0x20;
    public static int PAW1_CLOSE = 0x21;
    public static int PAW2_OPEN = 0x22;
    public static int PAW2_CLOSE = 0x23;
    public static int PAW3_OPEN = 0x24;
    public static int PAW3_CLOSE = 0x25;
    public static int PAW4_OPEN = 0x26;
    public static int PAW4_CLOSE = 0x27;
    public static int PAW5_OPEN = 0x28;
    public static int PAW5_CLOSE = 0x29;
}
