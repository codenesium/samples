using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductModel: AbstractBusinessObject
        {
                public AbstractBOProductModel() : base()
                {
                }

                public virtual void SetProperties(int productModelID,
                                                  string catalogDescription,
                                                  string instructions,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instructions = instructions;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductModelID = productModelID;
                        this.Rowguid = rowguid;
                }

                public string CatalogDescription { get; private set; }

                public string Instructions { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductModelID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>236f0ccc64e5fafa4e227ed5f6671c4f</Hash>
</Codenesium>*/