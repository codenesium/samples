using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSpecialOfferRequestModel : AbstractApiRequestModel
        {
                public ApiSpecialOfferRequestModel()
                        : base()
                {
                }

                public void SetProperties(
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
                        this.StartDate = startDate;
                        this.Type = type;
                }

                private string category;

                [Required]
                public string Category
                {
                        get
                        {
                                return this.category;
                        }

                        set
                        {
                                this.category = value;
                        }
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private decimal discountPct;

                [Required]
                public decimal DiscountPct
                {
                        get
                        {
                                return this.discountPct;
                        }

                        set
                        {
                                this.discountPct = value;
                        }
                }

                private DateTime endDate;

                [Required]
                public DateTime EndDate
                {
                        get
                        {
                                return this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
                        }
                }

                private Nullable<int> maxQty;

                public Nullable<int> MaxQty
                {
                        get
                        {
                                return this.maxQty.IsEmptyOrZeroOrNull() ? null : this.maxQty;
                        }

                        set
                        {
                                this.maxQty = value;
                        }
                }

                private int minQty;

                [Required]
                public int MinQty
                {
                        get
                        {
                                return this.minQty;
                        }

                        set
                        {
                                this.minQty = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
                        }
                }

                private string type;

                [Required]
                public string Type
                {
                        get
                        {
                                return this.type;
                        }

                        set
                        {
                                this.type = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>fb8c71dbb7a3ffb79cae7578735440e5</Hash>
</Codenesium>*/