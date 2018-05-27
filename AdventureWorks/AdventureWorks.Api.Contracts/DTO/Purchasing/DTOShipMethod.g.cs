using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOShipMethod: AbstractDTO
	{
		public DTOShipMethod() : base()
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

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public decimal ShipBase { get; set; }
		public int ShipMethodID { get; set; }
		public decimal ShipRate { get; set; }
	}
}

/*<Codenesium>
    <Hash>30a21edcb8769828880c5bcf49b3b884</Hash>
</Codenesium>*/