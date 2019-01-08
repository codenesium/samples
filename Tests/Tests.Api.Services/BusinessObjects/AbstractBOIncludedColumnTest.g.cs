using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOIncludedColumnTest : AbstractBusinessObject
	{
		public AbstractBOIncludedColumnTest()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  string name2)
		{
			this.Id = id;
			this.Name = name;
			this.Name2 = name2;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d82e33c7b033d008a9ab55e1547cd028</Hash>
</Codenesium>*/