using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4Processor
{
    public interface TemplateProcessor
    {
        string FileExtension { get; }

        bool HasErrors { get; }

        ProcessorError[] Errors { get; }

        string ProcessTemplate(string templateFileName, Dictionary<string, object> parameters = null);
    }
}
