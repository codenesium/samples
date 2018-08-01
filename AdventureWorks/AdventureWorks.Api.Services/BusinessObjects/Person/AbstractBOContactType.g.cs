using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOContactType : AbstractBusinessObject
	{
		public AbstractBOContactType()
			: base()
		{
		}

		public virtual void SetProperties(int contactTypeID,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.ContactTypeID = contactTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		public int ContactTypeID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9a84f4317e7a6be9e1405d18f25e9f76</Hash>
</Codenesium>*/