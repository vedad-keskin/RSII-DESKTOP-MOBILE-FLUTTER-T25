using System;

namespace eCommerce.Model.SearchObjects
{
    public class FavouritesSearchObject : BaseSearchObject
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }
}
