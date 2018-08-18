using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOPostTypes : AbstractBusinessObject
	{
		public AbstractBOPostTypes()
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
    <Hash>c17e2ddacd19b416c8fa52898531a261</Hash>
</Codenesium>*/