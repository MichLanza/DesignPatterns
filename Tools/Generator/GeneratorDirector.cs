using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator _builder;
        public GeneratorDirector(IBuilderGenerator builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilderGenerator builder)
        {
            _builder = builder;
        }

        public void GenerateJson(List<string> content, string path)
        {
            _builder.Reset();
            _builder.SetFormat(TypeFormat.Json);
            _builder.Path(path);
            _builder.SetContent(content);
        }

        public void GeneratePipes(List<string> content, string path)
        {
            _builder.Reset();
            _builder.SetFormat(TypeFormat.Pipes);
            _builder.SetCharacter(TypeCharacter.Uppercase);
            _builder.Path(path);
            _builder.SetContent(content);
        }
    }  
}
