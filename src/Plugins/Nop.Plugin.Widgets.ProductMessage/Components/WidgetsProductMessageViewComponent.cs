using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.ProductMessage.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.ProductMessage.Components
{
    public class WidgetsProductMessageViewComponent: NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;

        public WidgetsProductMessageViewComponent(IStoreContext storeContext, 
            IStaticCacheManager cacheManager, 
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var messageSettings = _settingService.LoadSetting<ProductMessageSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Message = messageSettings.Message
            };

            if (string.IsNullOrEmpty(model.Message))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.ProductMessage/Views/PublicInfo.cshtml", model);
        }
    }
}
