using it.unical.mat.embasp.languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace it.unical.mat.test.specialization.idlv
{
    [Id("path")]
    class UnweightedPath
    {
        [Param(0)]
        private int from;

        [Param(1)]
        private int to;

 

        public UnweightedPath()
        {
            this.from = 0;
            this.to = 0;
        }

        public UnweightedPath(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public int getFrom()
        {
            return from;
        }

        public void setFrom(int from)
        {
            this.from = from;
        }

        public int getTo()
        {
            return to;
        }

        public void setTo(int to)
        {
            this.to = to;
        }

        public override string ToString()
        {
            return "path(" + from + "," + to + ").";
        }
    }
}