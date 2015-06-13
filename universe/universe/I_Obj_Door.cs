using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace universe
{
    class I_Obj_Door : Interactive_Object
    {
        public I_Obj_Door(int x, int y, int state, int refnum) 
            : base(x, y, state, 0, 0, 0, 71, 65, 76, refnum, 0, 3, 0 ){
        }
    }
}
