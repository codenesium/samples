using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBillOfMaterialsRequestModel : AbstractApiRequestModel
        {
                public ApiBillOfMaterialsRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        short bOMLevel,
                        int componentID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        decimal perAssemblyQty,
                        Nullable<int> productAssemblyID,
                        DateTime startDate,
                        string unitMeasureCode)
                {
                        this.BOMLevel = bOMLevel;
                        this.ComponentID = componentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.PerAssemblyQty = perAssemblyQty;
                        this.ProductAssemblyID = productAssemblyID;
                        this.StartDate = startDate;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                private short bOMLevel;

                [Required]
                public short BOMLevel
                {
                        get
                        {
                                return this.bOMLevel;
                        }

                        set
                        {
                                this.bOMLevel = value;
                        }
                }

                private int componentID;

                [Required]
                public int ComponentID
                {
                        get
                        {
                                return this.componentID;
                        }

                        set
                        {
                                this.componentID = value;
                        }
                }

                private Nullable<DateTime> endDate;

                public Nullable<DateTime> EndDate
                {
                        get
                        {
                                return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
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

                private decimal perAssemblyQty;

                [Required]
                public decimal PerAssemblyQty
                {
                        get
                        {
                                return this.perAssemblyQty;
                        }

                        set
                        {
                                this.perAssemblyQty = value;
                        }
                }

                private Nullable<int> productAssemblyID;

                public Nullable<int> ProductAssemblyID
                {
                        get
                        {
                                return this.productAssemblyID.IsEmptyOrZeroOrNull() ? null : this.productAssemblyID;
                        }

                        set
                        {
                                this.productAssemblyID = value;
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

                private string unitMeasureCode;

                [Required]
                public string UnitMeasureCode
                {
                        get
                        {
                                return this.unitMeasureCode;
                        }

                        set
                        {
                                this.unitMeasureCode = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f9f8bcdbd80ea31afd5bcd7129cc1374</Hash>
</Codenesium>*/