using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.ProductMessage.Models
{
    public class ConfigurationModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ProductMessage.Message")]
        public string Message { get; set; }     
        public bool Message_OverrideForStore { get; set; }
    }

    public partial class ConfigurationLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ProductMessage.Message")]
        public string Message { get; set; }
    }
}
