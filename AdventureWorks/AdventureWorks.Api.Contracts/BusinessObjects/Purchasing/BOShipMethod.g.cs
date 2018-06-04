using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>0ba7c40a96d9a787707d57b5e9f2adbe</Hash>
</Codenesium>*/