using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiAdminRequestModel: AbstractApiRequestModel
        {
                public ApiAdminRequestModel() : base()
                {
                }

                public void SetProperties(
                        string email,
                        string firstName,
                        string lastName,
                        string password,
                        string phone,
                        string username)
                {
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Password = password;
                        this.Phone = phone;
                        this.Username = username;
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

                private string password;

                [Required]
                public string Password
                {
                        get
                        {
                                return this.password;
                        }

                        set
                        {
                                this.password = value;
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

                private string username;

                [Required]
                public string Username
                {
                        get
                        {
                                return this.username;
                        }

                        set
                        {
                                this.username = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>dab070f038a86a267726e93167fa535c</Hash>
</Codenesium>*/