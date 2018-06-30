using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityAddressRequestModel : AbstractApiRequestModel
        {
                public ApiBusinessEntityAddressRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
    <Hash>b26f43fffbaf3c39b09a2703f1e6f1d2</Hash>
</Codenesium>*/