using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductCategory: AbstractBusinessObject
        {
                public BOProductCategory() : base()
                {
                }

                public void SetProperties(int productCategoryID,
                                          DateTime modifiedDate,
                                          string name,
                                          Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3ff9a0c39ade72e423e6cb149e8def41</Hash>
</Codenesium>*/