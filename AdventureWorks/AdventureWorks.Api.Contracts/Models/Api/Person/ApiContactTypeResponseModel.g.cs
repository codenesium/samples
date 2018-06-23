using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiContactTypeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public int ContactTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeContactTypeIDValue { get; set; } = true;

                public bool ShouldSerializeContactTypeID()
                {
                        return this.ShouldSerializeContactTypeIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeContactTypeIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>85bb4ccf03bf40e0eb213626d891124f</Hash>
</Codenesium>*/