using AspNetCorePlayground.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCorePlayground.Web.TagHelpers
{
    [HtmlTargetElement("edit-input")]
    public class EditInputTagHelper : TagHelper
    {

        public EditInputTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public string LabelText { get; set; }

        [HtmlAttributeName("model-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        protected IHtmlGenerator Generator { get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var label = Generator.GenerateLabel(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                LabelText,
                null);
            output.Content.AppendHtml(label);

            var input = Generator.GenerateTextBox(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                For.ModelExplorer.Model,
                string.Empty,
                new { @class = "form-control" });
            output.Content.AppendHtml(input);

            var validation = Generator.GenerateValidationMessage(
                ViewContext,
                For.ModelExplorer,
                For.Name,
                string.Empty,
                "span",
                new { @class = "text-danger" });
            output.Content.AppendHtml(validation);
        }

    }
}
