using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductInventoryRequestModel : AbstractApiRequestModel
        {
                public ApiProductInventoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int bin,
                        short locationID,
                        DateTime modifiedDate,
                        short quantity,
                        Guid rowguid,
                        string shelf)
                {
                        this.Bin = bin;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.Quantity = quantity;
                        this.Rowguid = rowguid;
                        this.Shelf = shelf;
                }

                private int bin;

                [Required]
                public int Bin
                {
                        get
                        {
                                return this.bin;
                        }

                        set
                        {
                                this.bin = value;
                        }
                }

                private short locationID;

                [Required]
                public short LocationID
                {
                        get
                        {
                                return this.locationID;
                        }

                        set
                        {
                                this.locationID = value;
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

                private short quantity;

                [Required]
                public short Quantity
                {
                        get
                        {
                                return this.quantity;
                        }

                        set
                        {
                                this.quantity = value;
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

                private string shelf;

                [Required]
                public string Shelf
                {
                        get
                        {
                                return this.shelf;
                        }

                        set
                        {
                                this.shelf = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>431784e2e551229b742fc97adbccdc02</Hash>
</Codenesium>*/