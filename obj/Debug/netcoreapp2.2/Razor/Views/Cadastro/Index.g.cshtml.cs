#pragma checksum "C:\Users\35883602800\Desktop\project-RoleTopMVC\Views\Cadastro\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fce2711ecc73d61b55258014f0e7156f8b22db9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_Index), @"mvc.1.0.view", @"/Views/Cadastro/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cadastro/Index.cshtml", typeof(AspNetCore.Views_Cadastro_Index))]
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
#line 1 "C:\Users\35883602800\Desktop\project-RoleTopMVC\Views\_ViewImports.cshtml"
using project_RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\35883602800\Desktop\project-RoleTopMVC\Views\_ViewImports.cshtml"
using project_RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fce2711ecc73d61b55258014f0e7156f8b22db9", @"/Views/Cadastro/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa9346c35ab2aa533a85ce99e20e39341cea489f", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadastro_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 56, true);
            WriteLiteral("<main>\r\n     <h2>Cadastra aí meu consagrado!</h2>\r\n     ");
            EndContext();
            BeginContext(56, 2099, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fce2711ecc73d61b55258014f0e7156f8b22db93695", async() => {
                BeginContext(129, 2019, true);
                WriteLiteral(@"
          <div>
               <label for=""nome"">Nome Completo</label>
               <br />
               <input id=""nome"" type=""text"" maxlength=""40"" minlength=""5"" name=""nome"" required>
          </div>

          <div>
               <label for=""cep"">CEP</label>
               <br />
               <input id=""cep"" type=""number"" maxlength=""8"" minlength=""8"" name=""cep""  required>
          </div>

          <div>
               <label for=""endereco"">Endereço</label>
               <br />
               <input id=""endereco"" type=""text"" maxlength=""50"" minlength=""4"" name=""endereco""required>
          </div>

          <div>
               <label for=""complemento"">Complemento</label>
               <br />
               <input id=""complemento"" type=""text"" maxlength=""12"" name=""complemento"">
          </div>

          <div>
               <label for=""telefone"">Telefone</label>
               <br />
               <input id=""telefone"" type=""number"" name=""telefone"" minlengh=""10"" maxlengt");
                WriteLiteral(@"h=""11"" required>

          </div>
          <div>
               <label for=""cpf/cnpj"">CPF/CNPJ</label>
               <br />
               <input id=""cpf/cnpj"" type=""number"" name=""cpf/cnpj"" minlength=""10"" maxlength=""11"" required>
          </div>
          
               <div>
               <label for=""email"">Email</label>
               <br />
               <input id=""email"" type=""email"" name=""email"" minlength=""10"" required>
          <div>

          <div>
               <label for=""senha"">Senha</label>
               <br />
               <input id=""senha"" type=""password"" maxlength=""20"" minlength=""6"" name=""senha"" required>
          </div>

          <div>
               <label for=""confirmar-senha"">Confirmar Senha</label>
               <br />
               <input id=""confirmar-senha"" type=""password"" maxlength=""20"" minlength=""6"" name=""confirmar-senha"" required/>
          </div>
          <input type=""submit"" value=""Finalizar Cadastro!"">
     ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
#line 3 "C:\Users\35883602800\Desktop\project-RoleTopMVC\Views\Cadastro\Index.cshtml"
AddHtmlAttributeValue("", 84, Url.Action("CadastrarCliente", "Cadastro"), 84, 43, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2155, 9, true);
            WriteLiteral("\r\n</main>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
