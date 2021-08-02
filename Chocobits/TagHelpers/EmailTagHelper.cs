using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Chocobits.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailTo { get; set; }
        public string LinkText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto: {EmailTo}");
            output.Content.SetContent(LinkText);
        }
    }
}
