using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductDocument: AbstractBusinessObject
        {
                public BOProductDocument() : base()
                {
                }

                public void SetProperties(int productID,
                                          Guid documentNode,
                                          DateTime modifiedDate)
                {
                        this.DocumentNode = documentNode;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                }

                public Guid DocumentNode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7aeddc7f6cc99c52c8710422d16a9232</Hash>
</Codenesium>*/