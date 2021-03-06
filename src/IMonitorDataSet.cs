﻿#region SearchAThing.Graph, Copyright(C) 2015-2016 Lorenzo Delana, License under MIT
/*
* The MIT License(MIT)
* Copyright(c) 2016 Lorenzo Delana, https://searchathing.com
*
* Permission is hereby granted, free of charge, to any person obtaining a
* copy of this software and associated documentation files (the "Software"),
* to deal in the Software without restriction, including without limitation
* the rights to use, copy, modify, merge, publish, distribute, sublicense,
* and/or sell copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
* DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAThing.Graph
{
    
    /// <summary>
    /// Define a timerange past from now.
    /// </summary>
    public interface IMonitorDataSet
    {

        /// <summary>
        /// Timespan range name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Timespan value.
        /// </summary>
        TimeSpan? TimespanTotal { get; }

        /// <summary>
        /// Max number of sample points.
        /// </summary>
        int SizeMax { get; }

        /// <summary>
        /// Gets the timespan interval foreach sample average.
        /// </summary>
        TimeSpan? TimespanInterval { get; }

        /// <summary>
        /// Plot points gathered from now back to timespan.
        /// </summary>
        IEnumerable<IMonitorData> Points { get; }

        /// <summary>
        /// Add the given data to the dataset.        
        /// </summary>        
        /// <param name="timestamp">If not null let simulate an arbitrary current time (used primarly by unit tests).</param>
        void Add(IMonitorData data, DateTime? currentTime = null);

    }

}
