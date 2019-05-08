﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views
{
    public interface ILoadingView
    {
        void SetLoadingText(string text);
        void SetProgress(int progressValue);
    }
}
