using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model.Setting
{
   public interface ISettingsOperation
    {
        ISettingsModel Load();
        
        void Save(ISettingsModel settings);
        
    }
}
