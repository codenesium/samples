using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOStore : AbstractBusinessObject
	{
		public AbstractBOStore()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  string demographic,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  Guid rowguid,
		                                  int? salesPersonID)
		{
			this.BusinessEntityID = businessEntityID;
			this.Demographic = demographic;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesPersonID = salesPersonID;
		}

		public int BusinessEntityID { get; private set; }

		public string Demographic { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public Guid Rowguid { get; private set; }

		public int? SalesPersonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>53a8a8432c94fa3d4784ce6f815f5f8e</Hash>
</Codenesium>*/