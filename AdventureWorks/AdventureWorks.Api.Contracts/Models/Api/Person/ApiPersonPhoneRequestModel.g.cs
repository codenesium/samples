using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonPhoneRequestModel : AbstractApiRequestModel
        {
                public ApiPersonPhoneRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string phoneNumber,
                        int phoneNumberTypeID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.PhoneNumber = phoneNumber;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string PhoneNumber { get; private set; }

                [Required]
                [JsonProperty]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5f4009110ed7fd581f501d3a9eb9ff39</Hash>
</Codenesium>*/