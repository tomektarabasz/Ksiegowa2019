using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Ksiegowa2019.windowsUserSimulation
{
    class Boot
    {
        public void calculator()
        {
            Ribbon ribbon = new Ribbon();
            System.Windows.Forms.RibbonContext ribbonContext = new RibbonContext(ribbon);
            Console.WriteLine(ribbonContext.Text);
        }

    }
}
