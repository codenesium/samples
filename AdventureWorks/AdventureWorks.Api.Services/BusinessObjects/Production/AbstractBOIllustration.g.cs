using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOIllustration : AbstractBusinessObject
	{
		public AbstractBOIllustration()
			: base()
		{
		}

		public virtual void SetProperties(int illustrationID,
		                                  string diagram,
		                                  DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID;
			this.ModifiedDate = modifiedDate;
		}

		public string Diagram { get; private set; }

		public int IllustrationID { get; private set; }

		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5efb5044d2f87736f423edda4a9be53a</Hash>
</Codenesium>*/