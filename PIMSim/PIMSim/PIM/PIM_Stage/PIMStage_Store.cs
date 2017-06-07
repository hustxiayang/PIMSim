﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePIM.General;

namespace SimplePIM.PIM
{
    public class PIMStage_Store : Stage
    {

        public override void set_input(object obj)
        {
            if (last != null)
            {
                if (last[0].output_ready)
                    input_ready = true;
                else
                    input_ready = false;
            }else
                input_ready = false;

        }
        public PIMStage_Store(object parent)
        {
            Parent = parent;
        }
        public override bool read_input()
        {
            if (input_ready)
            {
                intermid = 0;
                input_ready = false;
                input = null;
                return true;
            }
            else
            {
                intermid = null;
            }
            return false;
        }

        public override bool Step()
        {
            stall = false;
            //add code to load data
            set_input(null);
          if(read_input())
            {
                write_output();
                (Parent as ComputationalUnit).write_callback(0, 0);
                return true;
            }
            

            return false;
        }


    }
}
