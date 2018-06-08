using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiAddressRequestModel: AbstractApiRequestModel
        {
                public ApiAddressRequestModel() : base()
                {
                }

                public void SetProperties(
                        string addressLine1,
                        string addressLine2,
                        string city,
                        DateTime modifiedDate,
                        string postalCode,
                        Guid rowguid,
                        int stateProvinceID)
                {
                        this.AddressLine1 = addressLine1;
                        this.AddressLine2 = addressLine2;
                        this.City = city;
                        this.ModifiedDate = modifiedDate;
                        this.PostalCode = postalCode;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                }

                private string addressLine1;

                [Required]
                public string AddressLine1
                {
                        get
                        {
                                return this.addressLine1;
                        }

                        set
                        {
                                this.addressLine1 = value;
                        }
                }

                private string addressLine2;

                public string AddressLine2
                {
                        get
                        {
                                return this.addressLine2.IsEmptyOrZeroOrNull() ? null : this.addressLine2;
                        }

                        set
                        {
                                this.addressLine2 = value;
                        }
                }

                private string city;

                [Required]
                public string City
                {
                        get
                        {
                                return this.city;
                        }

                        set
                        {
                                this.city = value;
                        }
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

                private string postalCode;

                [Required]
                public string PostalCode
                {
                        get
                        {
                                return this.postalCode;
                        }

                        set
                        {
                                this.postalCode = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private int stateProvinceID;

                [Required]
                public int StateProvinceID
                {
                        get
                        {
                                return this.stateProvinceID;
                        }

                        set
                        {
                                this.stateProvinceID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>6d76cfd19dd8065286dd33dcf0681b0b</Hash>
</Codenesium>*/