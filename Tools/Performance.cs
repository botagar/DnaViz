using System;
using Microsoft.Xna.Framework;

public class Performance
{
    private TimeSpan deltaTime;
    private TimeSpan[] elapsedTimes;
    private int timeHistoryIndex = 0;

    public Performance() {
        elapsedTimes = new TimeSpan[100];
    }

    public void FrameUpdated(GameTime gameTime)
    {
        deltaTime = gameTime.ElapsedGameTime;
        elapsedTimes[timeHistoryIndex++] = gameTime.ElapsedGameTime;
        if (timeHistoryIndex == 100) timeHistoryIndex = 0;
    }

    public float CurrentAverageFrameRate(TimeSpan overTimeOf)
    {

        return 1f;
    }

    public float CurrentInstantaneousFrameRate()
    {
        return 1f / (float)deltaTime.TotalSeconds;
    }
}