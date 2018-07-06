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

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>de45d0028a7224f4988aa3a07d3ac014</Hash>
</Codenesium>*/