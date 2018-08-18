using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOBusinessEntityContact : AbstractBusinessObject
	{
		public AbstractBOBusinessEntityContact()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  int contactTypeID,
		                                  DateTime modifiedDate,
		                                  int personID,
		                                  Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ContactTypeID = contactTypeID;
			this.ModifiedDate = modifiedDate;
			this.PersonID = personID;
			this.Rowguid = rowguid;
		}

		public int BusinessEntityID { get; private set; }

		public int ContactTypeID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int PersonID { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d7192c02878ce8cd642cec518b193466</Hash>
</Codenesium>*/