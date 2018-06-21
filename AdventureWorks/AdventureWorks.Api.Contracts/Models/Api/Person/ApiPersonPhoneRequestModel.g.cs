using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>4ac690c775a92f2547d09b47f1483320</Hash>
</Codenesium>*/