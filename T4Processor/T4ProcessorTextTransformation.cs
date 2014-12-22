using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TextTemplating;

namespace T4Processor
{
    public class T4ProcessorTextTransformation : TextTransformation
    {
        public IDictionary<string, object> ProcessorSession
        {
            get 
            {
                return this.Session;
            }
        }
        public T4ProcessorTextTransformation()
        {
            
        }

        #region Methods

        public override string TransformText()
        {
            return this.GenerationEnvironment.ToString();
        }

        #endregion Methods
    }
}
