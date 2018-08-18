using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOCulture : AbstractBusinessObject
	{
		public AbstractBOCulture()
			: base()
		{
		}

		public virtual void SetProperties(string cultureID,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		public string CultureID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f99933491f1d89f58b2f4de91089fdaa</Hash>
</Codenesium>*/