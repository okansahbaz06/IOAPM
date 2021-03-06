#pragma checksum "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cefd88d1cbd8d81dd7f658ddc39fd303a2f20773"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_MyProject), @"mvc.1.0.view", @"/Views/Project/MyProject.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\APM_17.06.2022\APM\APM.UI\Views\_ViewImports.cshtml"
using APM.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\APM_17.06.2022\APM\APM.UI\Views\_ViewImports.cshtml"
using APM.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\APM_17.06.2022\APM\APM.UI\Views\_ViewImports.cshtml"
using APM.Repository.Authorize;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\APM_17.06.2022\APM\APM.UI\Views\_ViewImports.cshtml"
using APM.Repository.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cefd88d1cbd8d81dd7f658ddc39fd303a2f20773", @"/Views/Project/MyProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb9cdc116c7958ba9ad1a096d94f213592159070", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_MyProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APM.Repository.Dto.ProjectAllDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
  
	ViewData["Title"] = "Projelerim";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""ecommerce-widget"">
	<div class=""row"" style=""justify-content: center;"">
		<div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
			<div class=""page-header"">
				<h2 class=""pageheader-title"">Projelerim</h2>
			</div>
		</div>
		<div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
			<div class=""card"">
				<h5 class=""card-header"">Proje Bilgileri</h5>
				<div class=""text-center"">
					<div class=""card-body p-0"">
						<div class=""table-responsive"">
							<div class=""table-hover"">
								<table class=""table table-striped table-bordered first"" id=""tb"">
									<thead class=""bg-light"">
										<tr class=""border-0"">
											<th class=""border-0"">#</th>
											<th class=""border-0"">Ad</th>
											<th class=""border-0"">Tipi</th>
											<th class=""border-0"">M??sterisi</th>
											<th class=""border-0"">Durum</th>
											<th class=""border-0"">Seviye</th>
											<th class=""border-0"">Olu??turan</th>
											<th class=""border-0"">Pln. Ba??. Tarih");
            WriteLiteral(@"i</th>
											<th class=""border-0"">Pln. Bt??. Tarihi</th>
											<th class=""border-0"">Ba??lama Tarihi</th>
											<th class=""border-0"">Biti?? Tarihi</th>
											<th class=""border-0"">Olu??turma Tarihi</th>
											<th class=""border-0"">Olu??turma Saati</th>
										</tr>
									</thead>
									<tbody>
");
#nullable restore
#line 39 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                         foreach (var item in Model.ProjectDto)
										{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 1534, "\"", 1547, 1);
#nullable restore
#line 42 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 1539, item.ID, 1539, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 42 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                             Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 1580, "\"", 1598, 2);
#nullable restore
#line 43 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 1585, item.ID, 1585, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1593, "-name", 1593, 5, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                  Write(item.NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 1632, "\"", 1650, 2);
#nullable restore
#line 44 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 1637, item.ID, 1637, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1645, "-type", 1645, 5, true);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 44 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                           Write(item.PROJECT_TYPE_.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 44 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                                                   Write(item.PROJECT_TYPE_.TYPE_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 1736, "\"", 1758, 2);
#nullable restore
#line 45 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 1741, item.ID, 1741, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1749, "-customer", 1749, 9, true);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 45 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                               Write(item.CUSTOMER.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 45 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                                                  Write(item.CUSTOMER.CUSTOMER_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                 if (item.STATUS == true)
												{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 1893, "\"", 1913, 2);
#nullable restore
#line 48 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 1898, item.ID, 1898, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1906, "-status", 1906, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Aktif</td>\r\n");
#nullable restore
#line 49 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
												}

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                 if (item.STATUS == false)
												{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2013, "\"", 2033, 2);
#nullable restore
#line 52 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2018, item.ID, 2018, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2026, "-status", 2026, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Pasif</td>\r\n");
#nullable restore
#line 53 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
												}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2077, "\"", 2096, 2);
#nullable restore
#line 54 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2082, item.ID, 2082, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2090, "-level", 2090, 6, true);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 54 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                            Write(item.LEVEL.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 54 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                                            Write(item.LEVEL.LEVEL_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2167, "\"", 2188, 2);
#nullable restore
#line 55 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2172, item.ID, 2172, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2180, "-creator", 2180, 8, true);
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 55 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                              Write(item.CREATED_EMPLOYEE.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 55 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                                                         Write(item.CREATED_EMPLOYEE.EMPLOYEE_NAME);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                                                                                              Write(item.CREATED_EMPLOYEE.EMPLOYEE_SURNAME);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2324, "\"", 2346, 2);
#nullable restore
#line 56 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2329, item.ID, 2329, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2337, "-estStart", 2337, 9, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                      Write(item.EST_START_DATE.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2413, "\"", 2433, 2);
#nullable restore
#line 57 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2418, item.ID, 2418, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2426, "-estEnd", 2426, 7, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 57 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                    Write(item.EST_END_DATE.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2498, "\"", 2517, 2);
#nullable restore
#line 58 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2503, item.ID, 2503, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2511, "-start", 2511, 6, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 58 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                   Write(item.START_DATE?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td");
            BeginWriteAttribute("id", " id=\"", 2581, "\"", 2598, 2);
#nullable restore
#line 59 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
WriteAttributeValue("", 2586, item.ID, 2586, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2594, "-end", 2594, 4, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 59 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                                                 Write(item.END_DATE?.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 60 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                               Write(item.CREATED_DATE.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 61 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
                                               Write(item.CREATED_TIME.ToString("hh':'mm':'ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 63 "D:\APM_17.06.2022\APM\APM.UI\Views\Project\MyProject.cshtml"
										}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t</tbody>\r\n\t\t\t\t\t\t\t\t</table>\r\n\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APM.Repository.Dto.ProjectAllDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
