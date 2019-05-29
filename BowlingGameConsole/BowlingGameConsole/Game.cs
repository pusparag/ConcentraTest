using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameConsole
{
    public class Game
    {
        private List<Frame> Frames;

        #region constructor
        public Game()
        {
            Frames = new List<Frame>();
        }

        #endregion

        #region public Methods
        public void Roll(int pins)
        {
            var frame = GetCurrentFrame();

            frame.AddRoll(pins);

            foreach (var fr in Frames.Where(f => f != frame && f.PendingBallsToTrack > 0))
            {
                fr.FrameScore += pins;
                fr.PendingBallsToTrack--;
            }
        }

        public int Score()
        {
            return Frames.Sum(f => f.FrameScore);
        }

        public void PrintScoreBoard()
        {
            Console.WriteLine(string.Join("|", Frames.Select(f => { string v = string.Join("   ", f.RollScores.Select(r => $"{r,2}")); return $"{v,7}"; })));
            var total = 0;
            Console.WriteLine(string.Join("|", Frames.Select(f => { total += f.FrameScore; return $"  {total,3}  "; })));
        }
        #endregion
        private Frame GetCurrentFrame()
        {
            Frame frame;
            if (Frames.Count == 0 || Frames[Frames.Count - 1].FrameHitsLeft == 0)
            {
                if (Frames.Count == 10)
                {
                    if (Frames[9].RollScores.Count >= 3)
                        throw new Exception("Game Has Finished");

                    frame = Frames[9];
                }
                else
                {
                    frame = new Frame();
                    Frames.Add(frame);
                }
            }
            else
            {
                frame = Frames[Frames.Count - 1];
            }

            return frame;
        }
    }


    internal class Frame
    {
        public Frame()
        {
            RollScores = new List<int>();
            FrameScore = 0;
            PendingBallsToTrack = 0;
            FrameHitsLeft = 2;
        }

        public List<int> RollScores { get; private set; }
        public int FrameScore { get; set; }
        public int PendingBallsToTrack { get; set; }
        public int FrameHitsLeft { get; private set; }

        public void AddRoll(int pins)
        {
            if ((RollScores.Sum() + pins) > 10 && PendingBallsToTrack == 0)
                throw new Exception("Invalid number of total pins for frame");

            RollScores.Add(pins);
            FrameHitsLeft--;
            FrameScore += pins;
            if (pins == 10)
            {
                PendingBallsToTrack = 2;
                FrameHitsLeft--;
            }
            else if (RollScores.Sum() == 10)
                PendingBallsToTrack = 1;
        }
    }
}
