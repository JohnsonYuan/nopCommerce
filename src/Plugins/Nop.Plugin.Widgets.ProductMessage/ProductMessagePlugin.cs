using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.ProductMessage
{
    public class ProductMessagePlugin : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        public ProductMessagePlugin(IWebHelper webHelper, ISettingService settingService)
        {
            this._webHelper = webHelper;
            this._settingService = settingService;
        }      
        
        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsProductMessage/Configure";
        }

        #region IWidget plugin

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsProductMessage";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsOverviewTop };
        }

        #endregion

        #region Base plugin

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //settings
            var settings = new ProductMessageSettings
            {
                Message = "default message"
            };

            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ProductMessage.Message", "Product message");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ProductMessage.Message.Hint", "Enter a product display message. Leave empty if you don't want to display any text.");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ProductMessageSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.ProductMessage.Message");
            this.DeletePluginLocaleResource("Plugins.Widgets.ProductMessage.Message.Hint");

            base.Uninstall();
        }

        #endregion
    }
}
