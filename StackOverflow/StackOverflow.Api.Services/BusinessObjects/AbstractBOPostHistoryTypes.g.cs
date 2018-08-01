using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOPostHistoryTypes : AbstractBusinessObject
	{
		public AbstractBOPostHistoryTypes()
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
    <Hash>8c006b2b098420413324ed6fc7636046</Hash>
</Codenesium>*/