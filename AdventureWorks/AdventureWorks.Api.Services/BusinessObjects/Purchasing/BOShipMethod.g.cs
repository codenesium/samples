using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOShipMethod: AbstractBusinessObject
	{
		public BOShipMethod() : base()
		{}

		public void SetProperties(int shipMethodID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          decimal shipBase,
		                          decimal shipRate)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.ShipBase = shipBase.ToDecimal();
			this.ShipMethodID = shipMethodID.ToInt();
			this.ShipRate = shipRate.ToDecimal();
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
    <Hash>7ded082a2550da6e0ca9c195649fda66</Hash>
</Codenesium>*/