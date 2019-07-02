﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinowySystemRezerwacji.view
{
    /// <summary>
    /// Komponent zawierający kalendarz do wyboru daty seansu.
    /// </summary>
    internal partial class ExtendedMonthCalendar : UserControl
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        internal ExtendedMonthCalendar()
        {
            InitializeComponent();
            monthCalendar.MinDate = DateTime.Now;
        }

        internal event Action<DateTime> RequestShowingsList;

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            RequestShowingsList?.Invoke(e.Start);
        }
    }
}