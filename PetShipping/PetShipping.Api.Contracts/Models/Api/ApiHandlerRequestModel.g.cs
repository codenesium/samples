using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiHandlerRequestModel : AbstractApiRequestModel
        {
                public ApiHandlerRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        string email,
                        string firstName,
                        string lastName,
                        string phone)
                {
                        this.CountryId = countryId;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                }

                private int countryId;

                [Required]
                public int CountryId
                {
                        get
                        {
                                return this.countryId;
                        }

                        set
                        {
                                this.countryId = value;
                        }
                }

                private string email;

                [Required]
                public string Email
                {
                        get
                        {
                                return this.email;
                        }

                        set
                        {
                                this.email = value;
                        }
                }

                private string firstName;

                [Required]
                public string FirstName
                {
                        get
                        {
                                return this.firstName;
                        }

                        set
                        {
                                this.firstName = value;
                        }
                }

                private string lastName;

                [Required]
                public string LastName
                {
                        get
                        {
                                return this.lastName;
                        }

                        set
                        {
                                this.lastName = value;
                        }
                }

                private string phone;

                [Required]
                public string Phone
                {
                        get
                        {
                                return this.phone;
                        }

                        set
                        {
                                this.phone = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>218af0f516553b1c256deedf283c6d0f</Hash>
</Codenesium>*/