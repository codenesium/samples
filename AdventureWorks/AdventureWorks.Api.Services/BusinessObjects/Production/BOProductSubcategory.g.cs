using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductSubcategory: AbstractBusinessObject
        {
                public BOProductSubcategory() : base()
                {
                }

                public void SetProperties(int productSubcategoryID,
                                          DateTime modifiedDate,
                                          string name,
                                          int productCategoryID,
                                          Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public int ProductSubcategoryID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1557defacde0b7bd2703a2c0b432f954</Hash>
</Codenesium>*/