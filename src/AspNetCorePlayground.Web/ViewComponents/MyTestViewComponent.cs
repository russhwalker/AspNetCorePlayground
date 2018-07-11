using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePlayground.Web.ViewComponents
{
    public class MyTestViewComponent : ViewComponent
    {

        public MyTestViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            return View();
        }

    }
}
