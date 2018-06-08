using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOBillOfMaterials: AbstractBusinessObject
        {
                public BOBillOfMaterials() : base()
                {
                }

                public void SetProperties(int billOfMaterialsID,
                                          short bOMLevel,
                                          int componentID,
                                          Nullable<DateTime> endDate,
                                          DateTime modifiedDate,
                                          decimal perAssemblyQty,
                                          Nullable<int> productAssemblyID,
                                          DateTime startDate,
                                          string unitMeasureCode)
                {
                        this.BillOfMaterialsID = billOfMaterialsID;
                        this.BOMLevel = bOMLevel;
                        this.ComponentID = componentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.PerAssemblyQty = perAssemblyQty;
                        this.ProductAssemblyID = productAssemblyID;
                        this.StartDate = startDate;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                public int BillOfMaterialsID { get; private set; }

                public short BOMLevel { get; private set; }

                public int ComponentID { get; private set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public decimal PerAssemblyQty { get; private set; }

                public Nullable<int> ProductAssemblyID { get; private set; }

                public DateTime StartDate { get; private set; }

                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2be8f804da604133236c6143c07fc63c</Hash>
</Codenesium>*/