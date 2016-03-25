using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public enum Controls
{
    LT,
    RT,
    RB,
    LB,
    X,
    A,
    B,
    Y,
    Start,
    Back,
    RightStick,
    LeftStick,

}

public class XboxControls : MonoBehaviour {

    public float VibrateTime;
    public int VibratePower;

    private static XboxControls _instance;

    //This is the public reference that other classes will use
    public static XboxControls instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<XboxControls>();
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
	
    public void Vibrate(int pControllerNumber)
    {
        StartCoroutine(VibrateNTurnOff(pControllerNumber));
    }

    IEnumerator VibrateNTurnOff(int pControllerNumber)
    {
        GamePad.SetVibration((PlayerIndex)pControllerNumber, VibratePower, VibratePower);
        yield return new WaitForSeconds(VibrateTime);
        GamePad.SetVibration((PlayerIndex)pControllerNumber, 0, 0);
    }

    public static int MaxPlayers  = 4;

    private static GamePadState[] mCurrentGamePadState = new GamePadState[4];
    private static GamePadState[] mPreviousGamePadState = new GamePadState[4];

    public bool UserPressedButtonCheckAll(Controls pControls)
    {
        bool tPressedButton = false;

        for(int tControllerNumber = 0;tControllerNumber < MaxPlayers;tControllerNumber++)
        {
            if(UserPressedButton(pControls, tControllerNumber))
            {
                tPressedButton = true;
            }
        }

        return tPressedButton;
    }

    public bool UserPressedButton(Controls pControls,int pControllerNumber)
    {
        GamePadState tCurrentGamePadState = mCurrentGamePadState[pControllerNumber];
        GamePadState tPreviousGamePadState = mPreviousGamePadState[pControllerNumber];

        switch (pControls)
        {
             case Controls.LB:
                return tCurrentGamePadState.Buttons.LeftShoulder == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.LeftShoulder == XInputDotNetPure.ButtonState.Released;
            case Controls.RB:
                return tCurrentGamePadState.Buttons.RightShoulder == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.RightShoulder == XInputDotNetPure.ButtonState.Released;
            case Controls.LT:
                return tCurrentGamePadState.Triggers.Left > 0
                    && tPreviousGamePadState.Triggers.Left <= 0;
            case Controls.RT:
                return tCurrentGamePadState.Triggers.Right > 0
                    && tPreviousGamePadState.Triggers.Right <= 0;
            case Controls.A:
                return tCurrentGamePadState.Buttons.A == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.A == XInputDotNetPure.ButtonState.Released;
            case Controls.B:
                return tCurrentGamePadState.Buttons.B == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.B == XInputDotNetPure.ButtonState.Released;
            case Controls.X:
                return tCurrentGamePadState.Buttons.X == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.X == XInputDotNetPure.ButtonState.Released;
            case Controls.Y:
                return tCurrentGamePadState.Buttons.Y == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.Y == XInputDotNetPure.ButtonState.Released;
            case Controls.Back:
                return tCurrentGamePadState.Buttons.Back == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.Back == XInputDotNetPure.ButtonState.Released;
            case Controls.LeftStick:
                return tCurrentGamePadState.Buttons.LeftStick == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.LeftStick == XInputDotNetPure.ButtonState.Released;
            case Controls.RightStick:
                return tCurrentGamePadState.Buttons.RightStick == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.RightStick == XInputDotNetPure.ButtonState.Released;
            case Controls.Start:
                return tCurrentGamePadState.Buttons.Start == XInputDotNetPure.ButtonState.Pressed
                    && tPreviousGamePadState.Buttons.Start == XInputDotNetPure.ButtonState.Released;
               
                default :
                return false;
        }
    }

    public Vector2 ThumbStick(Controls pControl,int pControllerNumber)
    {
        GamePadState tCurrentGamePadState = mCurrentGamePadState[pControllerNumber];

        switch(pControl)
        {
            case Controls.LeftStick:
                return new Vector2(tCurrentGamePadState.ThumbSticks.Left.X, tCurrentGamePadState.ThumbSticks.Left.Y);

            case Controls.RightStick :
                return new Vector2(tCurrentGamePadState.ThumbSticks.Right.X, tCurrentGamePadState.ThumbSticks.Right.Y);


            default:
                return Vector2.zero;
        }
    }

    void Update()
    {
        SetStates();
    }

    void SetStates()
    {
        for (int tControllerNumber = 0; tControllerNumber < MaxPlayers; tControllerNumber++)
        {
            mPreviousGamePadState[tControllerNumber] = mCurrentGamePadState[tControllerNumber];
        }

        for (int tControllerNumber = 0; tControllerNumber < MaxPlayers; tControllerNumber++)
        {
            mCurrentGamePadState[tControllerNumber] = GamePad.GetState((PlayerIndex)tControllerNumber);
        }
    }
}
