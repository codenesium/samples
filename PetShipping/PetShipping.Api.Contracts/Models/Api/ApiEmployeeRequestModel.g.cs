using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiEmployeeRequestModel : AbstractApiRequestModel
        {
                public ApiEmployeeRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string firstName,
                        bool isSalesPerson,
                        bool isShipper,
                        string lastName)
                {
                        this.FirstName = firstName;
                        this.IsSalesPerson = isSalesPerson;
                        this.IsShipper = isShipper;
                        this.LastName = lastName;
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

                private bool isSalesPerson;

                [Required]
                public bool IsSalesPerson
                {
                        get
                        {
                                return this.isSalesPerson;
                        }

                        set
                        {
                                this.isSalesPerson = value;
                        }
                }

                private bool isShipper;

                [Required]
                public bool IsShipper
                {
                        get
                        {
                                return this.isShipper;
                        }

                        set
                        {
                                this.isShipper = value;
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
        }
}

/*<Codenesium>
    <Hash>e55650513180a78a199e87d0ad0c0a1a</Hash>
</Codenesium>*/