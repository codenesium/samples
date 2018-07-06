using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTaxRateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesTaxRateID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int stateProvinceID,
                        decimal taxRate,
                        int taxType)
                {
                        this.SalesTaxRateID = salesTaxRateID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesTaxRateID { get; private set; }

                public int StateProvinceID { get; private set; }

                public decimal TaxRate { get; private set; }

                public int TaxType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8c23657938e391ca033db2983a36acaa</Hash>
</Codenesium>*/