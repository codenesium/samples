using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSalesTaxRate: AbstractBusinessObject
        {
                public BOSalesTaxRate() : base()
                {
                }

                public void SetProperties(int salesTaxRateID,
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
                        this.SalesTaxRateID = salesTaxRateID;
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
    <Hash>6f0661a5f539a756ff4256c01b9d79d5</Hash>
</Codenesium>*/