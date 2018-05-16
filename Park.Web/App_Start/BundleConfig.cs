using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Park.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true; 
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));
            //bundles.Add(new ScriptBundle("~/bundles/googlemap", "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["GooglePlacesAPIKey"]));
            //bundles.Add(new ScriptBundle("~/bundles/kendo", "http://kendo.cdn.telerik.com/" + ConfigurationManager.AppSettings["KendoVersion"] + "/js/kendo.all.min.js").Include("~/Scripts/Vendors/kendo.js"));
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include( 
                "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/bootstrap.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/Vendors/respond.src.js",
                "~/Scripts/Vendors/angular.js",
                //signup
                "~/Scripts/Vendors/oauth.js",
                "~/Scripts/Vendors/angular-sanitize.js",
                //"~/Scripts/Vendors/googleplatform.js", 
                //signup
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",
                //"~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
               // "~/Scripts/Vendors/raphael.js",
                //"~/Scripts/Vendors/morris.js",
                "~/Scripts/Vendors/jquery.fancybox.js",
                "~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js",
                //
                "~/Scripts/Vendors/angular-animate.min.js",
                 //
                "~/Scripts/Vendors/fullScreenPlugin.js" 
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js", 
                "~/Scripts/spa/services/fileUploadService.js", 
                "~/Scripts/spa/layout/customPager.directive.js", 
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js", 
                "~/Scripts/spa/FileUpload/uploadCtrl.js", 
                "~/Scripts/spa/layout/app.min.js",
                "~/Scripts/spa/services/services.js",
                //custom 
                "~/Scripts/spa/directives/imageDefaultdirective.js", 
                 "~/Scripts/spa/home/createCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css/commoncss").Include(
                "~/content/css/site.css",
                "~/content/css/bootstrap.min.css",
                "~/content/css/bootstrap-theme.css", 
                //"~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css", 
                  "~/content/css/style.css" 
                ));
            //bundles.Add(new StyleBundle("~/Content/kendocss", "http://kendo.cdn.telerik.com/" + ConfigurationManager.AppSettings["KendoVersion"] + "/styles/kendo.common.min.css").Include("~/content/css/kendo.css"));
            //bundles.Add(new StyleBundle("~/Content/kendothemecss", "http://kendo.cdn.telerik.com/" + ConfigurationManager.AppSettings["KendoVersion"] + "/styles/kendo.default.min.css").Include("~/content/css/kendothemedefault.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}