using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4Processor
{
    public class ProcessorError
    {
        public int Line { get; set; }

        public int Column { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public string Filename { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
