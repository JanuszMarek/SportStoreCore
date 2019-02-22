using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lessons.Areas.UsingTagHelpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lessons.Areas.UsingTagHelpers.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectOptionTagHelper : TagHelper
    {
        private ITagRepository repository;

        public SelectOptionTagHelper(ITagRepository repo)
        {
            repository = repo;
        }

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.Append((await output.GetChildContentAsync(false)).GetContent());

            object selected;
            context.Items.TryGetValue(typeof(SelectTagHelper), out selected);

            IEnumerable<string> selectedValues = (selected as IEnumerable<string>) ?? Enumerable.Empty<string>();

            PropertyInfo property = typeof(TagCity).GetTypeInfo().GetDeclaredProperty(ModelFor.Name);

            foreach (string country in repository.Cities.Select(c => property.GetValue(c)).Distinct())
            {
                if (selectedValues.Any(s => s.Equals(country, StringComparison.OrdinalIgnoreCase)))
                {
                    output.Content
                        .AppendHtml($"<option selected>{country}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option>{country}</option>");
                }
            }

        }
    }
}
