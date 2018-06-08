using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiShipMethodRequestModel: AbstractApiRequestModel
        {
                public ApiShipMethodRequestModel() : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        decimal shipBase,
                        decimal shipRate)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.ShipBase = shipBase;
                        this.ShipRate = shipRate;
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
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

                private decimal shipBase;

                [Required]
                public decimal ShipBase
                {
                        get
                        {
                                return this.shipBase;
                        }

                        set
                        {
                                this.shipBase = value;
                        }
                }

                private decimal shipRate;

                [Required]
                public decimal ShipRate
                {
                        get
                        {
                                return this.shipRate;
                        }

                        set
                        {
                                this.shipRate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>f1fbe63a48a467c2901f16ee1e3fda4b</Hash>
</Codenesium>*/