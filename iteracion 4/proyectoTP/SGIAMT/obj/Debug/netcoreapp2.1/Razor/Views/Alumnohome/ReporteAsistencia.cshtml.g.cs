#pragma checksum "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cdcd7c77e61500ae77a82e116e1a74f7bab3bf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Alumnohome_ReporteAsistencia), @"mvc.1.0.view", @"/Views/Alumnohome/ReporteAsistencia.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Alumnohome/ReporteAsistencia.cshtml", typeof(AspNetCore.Views_Alumnohome_ReporteAsistencia))]
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
#line 1 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\_ViewImports.cshtml"
using SGIAMT;

#line default
#line hidden
#line 2 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\_ViewImports.cshtml"
using SGIAMT.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cdcd7c77e61500ae77a82e116e1a74f7bab3bf2", @"/Views/Alumnohome/ReporteAsistencia.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1fa653021c3525d8d2b47ab8c36c07c51924279", @"/Views/_ViewImports.cshtml")]
    public class Views_Alumnohome_ReporteAsistencia : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGIAMT.Controllers.Perfiles.AlumnohomeController.AsistenciaxUsuario1>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/RegistroStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TAsistencias", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detalle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:steelblue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Imprimirdocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:firebrick"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReporteAsistencia", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cod-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/EditarDatosAlumno.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
  
    ViewData["Title"] = "Alumno";
    Layout = "~/Views/Shared/_LayoutPerfil/_LayoutAlumno.cshtml";

#line default
#line hidden
            BeginContext(201, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(203, 132, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "351f0a75f02d4e479cd8636f62dc3634", async() => {
                BeginContext(209, 61, true);
                WriteLiteral("\r\n\r\n    <title>Reporte de Asistencia del Alumno</title>\r\n    ");
                EndContext();
                BeginContext(270, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2ca5e171fc364dbaab5f148f4c85a1c4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(326, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(335, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(339, 4196, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f325d5986d7441bafb517c86034cb14", async() => {
                BeginContext(345, 333, true);
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row "">
            <div class=""col-10 register-right"" style=""width : 100% ; float :left"">

                <h2>Reporte de Asistencia del Alumno</h2>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<label style=""color:black"">correo: ");
                EndContext();
                BeginContext(679, 18, false);
#line 22 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                            Write(ViewData["correo"]);

#line default
#line hidden
                EndContext();
                BeginContext(697, 153, true);
                WriteLiteral("</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <label style=\"color:black\">nombre :&nbsp;&nbsp; ");
                EndContext();
                BeginContext(851, 18, false);
#line 22 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                                                                                                                                                                                                        Write(ViewData["nombre"]);

#line default
#line hidden
                EndContext();
                BeginContext(869, 49, true);
                WriteLiteral(" </label><label style=\"color:black\">&nbsp;&nbsp; ");
                EndContext();
                BeginContext(919, 19, false);
#line 22 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                                                                                                                                                                                                                                                                            Write(ViewData["paterno"]);

#line default
#line hidden
                EndContext();
                BeginContext(938, 48, true);
                WriteLiteral("</label><label style=\"color:black\">&nbsp;&nbsp; ");
                EndContext();
                BeginContext(987, 19, false);
#line 22 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                Write(ViewData["materno"]);

#line default
#line hidden
                EndContext();
                BeginContext(1006, 50, true);
                WriteLiteral("</label>\r\n                <br />\r\n                ");
                EndContext();
                BeginContext(1056, 3420, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ec520225d8548ee9ec5ac25d1548c28", async() => {
                    BeginContext(1110, 177, true);
                    WriteLiteral("\r\n                    <br />\r\n                    <div class=\"form-group mb-2\">\r\n                        <label class=\"control-label\">dni</label>\r\n                        <input");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 1287, "\"", 1311, 1);
#line 28 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
WriteAttributeValue("", 1295, ViewData["dni"], 1295, 16, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(1312, 1645, true);
                    WriteLiteral(@" id=""dni"" name=""dni"" class=""form-control"" readonly=""readonly"" />

                    </div>

                    <div class=""form-group"">
                        <label class=""control-label"">semana</label>
                        <input class=""form-control"" id=""semana"" name=""semana"" />


                    </div>
                    <div class=""form-group"">
                        <label class=""control-label"">dia</label>
                        <input class=""form-control"" id=""dia"" name=""dia"" />
                        <br />
                        <input type=""submit"" value=""Buscar"" class=""btn btn-success"" id=""btnbuscar"">

                    </div>
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th style=""background-color: #D3DFEC"">
                                    Dni
                                </th>

                                <th style=""background-color: #D3DFEC"">
          ");
                    WriteLiteral(@"                          hora
                                </th>

                                <th style=""background-color: #D3DFEC"">
                                    estado asistencia
                                </th>

                                <th style=""background-color: #D3DFEC"">
                                    semana
                                </th>

                                <th style=""background-color: #D3DFEC"">
                                    dia
                                </th>
                            </tr>
                        </thead>

");
                    EndContext();
#line 70 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
                    BeginContext(3038, 108, true);
                    WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3147, 42, false);
#line 74 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FkIuDni));

#line default
#line hidden
                    EndContext();
                    BeginContext(3189, 115, true);
                    WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3305, 39, false);
#line 77 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                               Write(Html.DisplayFor(modelItem => item.hora));

#line default
#line hidden
                    EndContext();
                    BeginContext(3344, 115, true);
                    WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3460, 53, false);
#line 80 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                               Write(Html.DisplayFor(modelItem => item.VaEstadoAsistencia));

#line default
#line hidden
                    EndContext();
                    BeginContext(3513, 115, true);
                    WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3629, 41, false);
#line 83 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                               Write(Html.DisplayFor(modelItem => item.semana));

#line default
#line hidden
                    EndContext();
                    BeginContext(3670, 115, true);
                    WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3786, 38, false);
#line 86 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                               Write(Html.DisplayFor(modelItem => item.dia));

#line default
#line hidden
                    EndContext();
                    BeginContext(3824, 117, true);
                    WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
                    EndContext();
                    BeginContext(3941, 158, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8fc691a138e4be0baa40ed0bdf84320", async() => {
                        BeginContext(4088, 7, true);
                        WriteLiteral("Detalle");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 90 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                                                                                                       WriteLiteral(item.pkasistencia);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(4099, 40, true);
                    WriteLiteral("\r\n\r\n                                    ");
                    EndContext();
                    BeginContext(4139, 173, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22658973da1445e2991ec19426547eee", async() => {
                        BeginContext(4292, 16, true);
                        WriteLiteral("Imprimir Reporte");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                    if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                    {
                        throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                    }
                    BeginWriteTagHelperAttribute();
#line 92 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                                                                                                                                                             WriteLiteral(item.pkasistencia);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(4312, 78, true);
                    WriteLiteral("\r\n\r\n                                </td>\r\n                            </tr>\r\n");
                    EndContext();
#line 96 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
                        }

#line default
#line hidden
                    BeginContext(4417, 52, true);
                    WriteLiteral("\r\n\r\n                    </table>\r\n\r\n                ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4476, 52, true);
                WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4535, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4557, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 109 "C:\Users\Usuario\Desktop\proyectoTP\SGIAMT\Views\Alumnohome\ReporteAsistencia.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(4627, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(4631, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc0ad38ba91648699a2df173b2811759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4680, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGIAMT.Controllers.Perfiles.AlumnohomeController.AsistenciaxUsuario1>> Html { get; private set; }
    }
}
#pragma warning restore 1591
