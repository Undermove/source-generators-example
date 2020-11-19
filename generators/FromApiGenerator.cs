using System.Net.Http;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyGenerator
{
    [Generator]
    public class FromApiGenerator : ISourceGenerator
    {
        private HttpClient _apiClient;

        public void Execute(GeneratorExecutionContext context)
        {
            // begin creating the source we'll inject into the users compilation
            var sourceBuilder = new StringBuilder(@"
                using System;
                namespace FromApiGenerator
                {
                ");

            var apiResponse = _apiClient.GetAsync("").Result.Content.ReadAsStringAsync().Result;
            
            sourceBuilder.Append(apiResponse);
            
            // finish creating the source to inject
            sourceBuilder.Append(@"
                }");

            // inject the created source into the users compilation
            context.AddSource("fromApiGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            _apiClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            };
        }
    }
}