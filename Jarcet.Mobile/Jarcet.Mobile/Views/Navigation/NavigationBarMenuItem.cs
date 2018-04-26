using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarcet.Mobile.Views.Navigation
{

    public class NavigationBarMenuItem
    {
        public NavigationBarMenuItem()
        {
            TargetType = typeof(Qoute.Qoutes);
            Icon = "icon.png";
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string Icon { get; set; }
        
    }
}