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
    <Hash>65e1840fd910f3c7d0d98700d6a48aca</Hash>
</Codenesium>*/