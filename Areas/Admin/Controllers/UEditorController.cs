using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditorNetCore;

namespace yiran.Areas.Admin.Controllers
{
    [Route("api/[controller]")] //配置路由
    public class UEditorController : Controller
    {
        private UEditorService ue;
        public UEditorController(UEditorService ue)
        {
            this.ue = ue;
        }

        public void Do()
        {
            ue.DoAction(HttpContext);
        }
    }
}