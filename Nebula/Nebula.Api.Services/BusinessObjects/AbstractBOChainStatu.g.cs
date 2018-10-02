using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOChainStatu : AbstractBusinessObject
	{
		public AbstractBOChainStatu()
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
    <Hash>ffe79ba15fff414b2228fa99ab6c369c</Hash>
</Codenesium>*/