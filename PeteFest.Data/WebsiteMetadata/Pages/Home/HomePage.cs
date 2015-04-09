using PeteFest.Data.Core.DataObjects;

namespace PeteFest.Data.WebsiteMetadata.Pages.Home
{
    public class HomePage : DataObject
    {
        public string PreHeaderText { get; set; }

        public string HeaderText { get; set; }

        public string SummaryText { get; set; }

        public string TwitterWidgetId { get; set; }
    }
}
