using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOAddressType: AbstractBusinessObject
	{
		public BOAddressType() : base()
		{}

		public void SetProperties(int addressTypeID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
		}

		public int AddressTypeID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>113431faeb1e26a4b4c8569f819875ad</Hash>
</Codenesium>*/