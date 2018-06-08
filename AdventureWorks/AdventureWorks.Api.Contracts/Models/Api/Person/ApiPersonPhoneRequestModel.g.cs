using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonPhoneRequestModel: AbstractApiRequestModel
        {
                public ApiPersonPhoneRequestModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string phoneNumber,
                        int phoneNumberTypeID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.PhoneNumber = phoneNumber;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string phoneNumber;

                [Required]
                public string PhoneNumber
                {
                        get
                        {
                                return this.phoneNumber;
                        }

                        set
                        {
                                this.phoneNumber = value;
                        }
                }

                private int phoneNumberTypeID;

                [Required]
                public int PhoneNumberTypeID
                {
                        get
                        {
                                return this.phoneNumberTypeID;
                        }

                        set
                        {
                                this.phoneNumberTypeID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>bced21077c6a9c5b211ca119358fc4f9</Hash>
</Codenesium>*/