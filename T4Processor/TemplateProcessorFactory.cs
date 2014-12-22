using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4Processor
{
    public class TemplateProcessorFactory
    {
        public static TemplateProcessorFactory DefaultFactory()
        {
            return new TemplateProcessorFactory();
        }

        public TemplateProcessor CreateTemplateProcessor() 
        {
            return new T4TemplateProcessor();
        }
    }
}
