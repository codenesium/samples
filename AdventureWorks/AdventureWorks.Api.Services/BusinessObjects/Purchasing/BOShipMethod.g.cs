using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOShipMethod: AbstractBusinessObject
        {
                public BOShipMethod() : base()
                {
                }

                public void SetProperties(int shipMethodID,
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
                        this.ShipMethodID = shipMethodID;
                        this.ShipRate = shipRate;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public Guid Rowguid { get; private set; }

                public decimal ShipBase { get; private set; }

                public int ShipMethodID { get; private set; }

                public decimal ShipRate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7ced354c18d9e4fdf1ca61ec2efcdf78</Hash>
</Codenesium>*/