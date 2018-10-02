using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOPostHistoryType : AbstractBusinessObject
	{
		public AbstractBOPostHistoryType()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string type)
		{
			this.Id = id;
			this.Type = type;
		}

		public int Id { get; private set; }

		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1ae4fbd03bb6a31ab6d0c6dd16c5c37e</Hash>
</Codenesium>*/