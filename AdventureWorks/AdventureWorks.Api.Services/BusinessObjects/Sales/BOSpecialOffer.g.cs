using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSpecialOffer: AbstractBusinessObject
        {
                public BOSpecialOffer() : base()
                {
                }

                public void SetProperties(int specialOfferID,
                                          string category,
                                          string description,
                                          decimal discountPct,
                                          DateTime endDate,
                                          Nullable<int> maxQty,
                                          int minQty,
                                          DateTime modifiedDate,
                                          Guid rowguid,
                                          DateTime startDate,
                                          string type)
                {
                        this.Category = category;
                        this.Description = description;
                        this.DiscountPct = discountPct;
                        this.EndDate = endDate;
                        this.MaxQty = maxQty;
                        this.MinQty = minQty;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.SpecialOfferID = specialOfferID;
                        this.StartDate = startDate;
                        this.Type = type;
                }

                public string Category { get; private set; }

                public string Description { get; private set; }

                public decimal DiscountPct { get; private set; }

                public DateTime EndDate { get; private set; }

                public Nullable<int> MaxQty { get; private set; }

                public int MinQty { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SpecialOfferID { get; private set; }

                public DateTime StartDate { get; private set; }

                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f79391821d427eada103520b536d9107</Hash>
</Codenesium>*/