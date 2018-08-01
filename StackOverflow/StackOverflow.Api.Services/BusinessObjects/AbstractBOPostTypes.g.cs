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
    <Hash>f3eec03eb78364e7991faa0a4fbb12db</Hash>
</Codenesium>*/