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
    <Hash>f947453f2ff32c525c035f12e563b3b6</Hash>
</Codenesium>*/