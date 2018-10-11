using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOChainStatus : AbstractBusinessObject
	{
		public AbstractBOChainStatus()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>09254780d71ed91159c86bf402e3f770</Hash>
</Codenesium>*/