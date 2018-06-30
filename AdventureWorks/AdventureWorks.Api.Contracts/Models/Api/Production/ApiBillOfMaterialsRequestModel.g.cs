using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
                        short bOMLevel,
                        int componentID,
                        DateTime? endDate,
                        DateTime modifiedDate,
                        decimal perAssemblyQty,
                        int? productAssemblyID,
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

                private DateTime? endDate;

                public DateTime? EndDate
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

                private int? productAssemblyID;

                public int? ProductAssemblyID
                {
                        get
                        {
                                return this.productAssemblyID;
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
    <Hash>62efd814f53ab545d63feb8ccc1b2be2</Hash>
</Codenesium>*/