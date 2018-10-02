using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOCompositePrimaryKey : AbstractBusinessObject
	{
		public AbstractBOCompositePrimaryKey()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int id2)
		{
			this.Id = id;
			this.Id2 = id2;
		}

		public int Id { get; private set; }

		public int Id2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b9207d4dbb4276f451e42ec5d60d7892</Hash>
</Codenesium>*/