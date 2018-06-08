using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityAddressRequestModel: AbstractApiRequestModel
        {
                public ApiBusinessEntityAddressRequestModel() : base()
                {
                }

                public void SetProperties(
                        int addressID,
                        int addressTypeID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                private int addressID;

                [Required]
                public int AddressID
                {
                        get
                        {
                                return this.addressID;
                        }

                        set
                        {
                                this.addressID = value;
                        }
                }

                private int addressTypeID;

                [Required]
                public int AddressTypeID
                {
                        get
                        {
                                return this.addressTypeID;
                        }

                        set
                        {
                                this.addressTypeID = value;
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
        }
}

/*<Codenesium>
    <Hash>da1d5bc6fcf7924446588b5cdeb7c90e</Hash>
</Codenesium>*/