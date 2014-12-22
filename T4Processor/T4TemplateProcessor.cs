using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.CodeDom.Compiler;

namespace T4Processor
{    
    class T4TemplateProcessor : TemplateProcessor 
    {
        private CustomCommandLineHost host;
        private ITextTemplatingEngine engine;

        public T4TemplateProcessor()
        {
            this.host = new CustomCommandLineHost();
            this.engine = new Engine();
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateFileName"> O host necessita que o template esteja salvo em um arquivo para poder criar uma sessao valida e passar parametros para a engine</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string ProcessTemplate(string templateFileName, Dictionary<string, object> parameters = null)
        {
            host.TemplateFileValue = templateFileName;
            host.CreateSession();

            if (parameters != null)
                foreach (var parameter in parameters)
                    host.Session[parameter.Key] = parameter.Value;

            //Read the text template.
            var templateText = GetTextTemplate(templateFileName);
            
            return engine.ProcessTemplate(templateText, host);
        }

        private string GetTextTemplate(string templateFileName)
        {
            try
            {
                return File.ReadAllText(templateFileName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading template \"" + templateFileName + "\"", ex);
            }
        }

        public bool HasErrors { get { return (this.host != null) && (this.host.Errors != null) && (this.host.Errors.Count > 0); } }

        public ProcessorError[] Errors 
        { 
            get 
            {
                var errors = new List<ProcessorError>();

                foreach (CompilerError item in this.host.Errors)
                {
                    errors.Add(new ProcessorError() 
                    {
                        Column = item.Column,
                        Line = item.Line,
                        Code = item.ErrorNumber,
                        Text = item.ErrorText,
                        Filename = item.FileName
                    });
                }
                
                return errors.ToArray(); 
            } 
        }

        public string FileExtension 
        {
            get 
            {
                return this.host.FileExtension;
            }
        }
    }
}
