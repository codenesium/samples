using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTaxRateRequestModel : AbstractApiRequestModel
        {
                public ApiSalesTaxRateRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int stateProvinceID,
                        decimal taxRate,
                        int taxType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
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

                private int stateProvinceID;

                [Required]
                public int StateProvinceID
                {
                        get
                        {
                                return this.stateProvinceID;
                        }

                        set
                        {
                                this.stateProvinceID = value;
                        }
                }

                private decimal taxRate;

                [Required]
                public decimal TaxRate
                {
                        get
                        {
                                return this.taxRate;
                        }

                        set
                        {
                                this.taxRate = value;
                        }
                }

                private int taxType;

                [Required]
                public int TaxType
                {
                        get
                        {
                                return this.taxType;
                        }

                        set
                        {
                                this.taxType = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c55a79d1a3707ba277214eacad65d979</Hash>
</Codenesium>*/