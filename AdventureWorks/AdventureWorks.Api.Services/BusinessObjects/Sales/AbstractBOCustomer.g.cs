using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOCustomer : AbstractBusinessObject
	{
		public AbstractBOCustomer()
			: base()
		{
		}

		public virtual void SetProperties(int customerID,
		                                  string accountNumber,
		                                  DateTime modifiedDate,
		                                  int? personID,
		                                  Guid rowguid,
		                                  int? storeID,
		                                  int? territoryID)
		{
			this.AccountNumber = accountNumber;
			this.CustomerID = customerID;
			this.ModifiedDate = modifiedDate;
			this.PersonID = personID;
			this.Rowguid = rowguid;
			this.StoreID = storeID;
			this.TerritoryID = territoryID;
		}

		public string AccountNumber { get; private set; }

		public int CustomerID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int? PersonID { get; private set; }

		public Guid Rowguid { get; private set; }

		public int? StoreID { get; private set; }

		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>615575846b2ba74882941440cb04b5dc</Hash>
</Codenesium>*/