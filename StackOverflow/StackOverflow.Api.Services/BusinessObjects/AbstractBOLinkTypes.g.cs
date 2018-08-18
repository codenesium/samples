using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOLinkTypes : AbstractBusinessObject
	{
		public AbstractBOLinkTypes()
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
    <Hash>bb3d557a2b8689ad63b9913ee1f6ea07</Hash>
</Codenesium>*/