﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Data.GetPlaylist
{
    /// <summary>
    /// Response returned by GetPlaylist Method
    /// </summary>
    public class ResponseRootObject : BaseResponseRootObject
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Result result { get; set; }
    }
}
