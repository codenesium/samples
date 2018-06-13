using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductDocumentResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        Guid documentNode,
                        DateTime modifiedDate,
                        int productID)
                {
                        this.DocumentNode = documentNode;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                }

                public Guid DocumentNode { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDocumentNodeValue { get; set; } = true;

                public bool ShouldSerializeDocumentNode()
                {
                        return this.ShouldSerializeDocumentNodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDocumentNodeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>5f1579ef2a2e9cb5a565a058632ff681</Hash>
</Codenesium>*/