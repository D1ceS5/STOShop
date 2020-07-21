using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace STOChernysh.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/validation").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}