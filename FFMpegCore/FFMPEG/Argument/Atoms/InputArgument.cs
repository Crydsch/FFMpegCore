﻿using System;
using System.IO;
using System.Linq;

namespace FFMpegCore.FFMPEG.Argument
{
    /// <summary>
    /// Represents input parameter
    /// </summary>
    public class InputArgument : Argument<string[]>
    {
        public InputArgument()
        {
        }

        public InputArgument(params string[] values) : base(values)
        {
        }

        public InputArgument(params VideoInfo[] values) : base(values.Select(v => v.FullName).ToArray())
        {
        }

        public InputArgument(params FileInfo[] values) : base(values.Select(v => v.FullName).ToArray())
        {
        }

        public InputArgument(params Uri[] values) : base(values.Select(v => v.AbsoluteUri).ToArray())
        {
        }

        /// <summary>
        /// String representation of the argument
        /// </summary>
        /// <returns>String representation of the argument</returns>
        public override string GetStringValue()
        {
            return string.Join(" ", Value.Select(v => ArgumentStringifier.Input(v)));
        }
        public VideoInfo[] GetAsVideoInfo()
        {
            return Value.Select(v => new VideoInfo(v)).ToArray();
        }
    }
}
