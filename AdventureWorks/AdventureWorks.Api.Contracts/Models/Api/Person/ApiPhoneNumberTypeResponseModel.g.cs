using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPhoneNumberTypeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int phoneNumberTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>72c589f891d9145c53d1ffcce3cf793d</Hash>
</Codenesium>*/