using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientRequestModel : AbstractApiRequestModel
        {
                public ApiClientRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string email,
                        string firstName,
                        string lastName,
                        string notes,
                        string phone)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Notes = notes;
                        this.Phone = phone;
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

                private string notes;

                public string Notes
                {
                        get
                        {
                                return this.notes.IsEmptyOrZeroOrNull() ? null : this.notes;
                        }

                        set
                        {
                                this.notes = value;
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
    <Hash>55c9c64a0033c9ffdc76df6c1f1ddfdb</Hash>
</Codenesium>*/