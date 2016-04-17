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

    public class MonitorPlot : IMonitorPlot
    {
        Dictionary<string, IMonitorDataSet> dataSetsDict;

        IMonitorDataSet AddDataSetInternal(string name, TimeSpan? timespan)
        {
            var monitorTimespan = new MonitorDataSet(PlotWidth, name, timespan);
            dataSetsDict.Add(name, monitorTimespan);

            return monitorTimespan;
        }

        /// <summary>
        /// Name of default dataset.
        /// </summary>
        public const string DefaultDataSetName = "default";

        public IEnumerable<IMonitorDataSet> DataSets { get { return dataSetsDict.Values; } }

        public int PlotWidth { get; private set; }

        public void Add(IMonitorData data, DateTime? currentTime)
        {
            foreach (var ds in dataSetsDict.Values)
            {
                ds.Add(data, currentTime);
            }
        }

        public IMonitorDataSet AddDataSet(string name, TimeSpan timespan)
        {
            return AddDataSetInternal(name, timespan);
        }

        public MonitorPlot(int plotWidth)
        {
            dataSetsDict = new Dictionary<string, IMonitorDataSet>();
            PlotWidth = plotWidth;
            AddDataSetInternal(DefaultDataSetName, null);            
        }

    }

}
