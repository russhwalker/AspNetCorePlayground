using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePlayground.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCorePlayground.Web.TagHelpers
{
    [HtmlTargetElement("customer-input")]
    public class CustomerInputTagHelper : TagHelper
    {
        //https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.TagHelpers/LabelTagHelper.cs
        public CustomerInputTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public CustomerViewModel Customer { get; set; }

        [HtmlAttributeName("customer-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected IHtmlGenerator Generator { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //output.TagName = "div";
            //output.Content.SetHtmlContent("<strong>test</strong>");
            

            var tag = Generator.GenerateTextBox(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                For.ModelExplorer.Model,
                string.Empty,
                null);            

            output.Content.SetHtmlContent(tag.InnerHtml);
        }

    }
}
