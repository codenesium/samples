using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBORowVersionCheck : AbstractBusinessObject
	{
		public AbstractBORowVersionCheck()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  Guid rowVersion)
		{
			this.Id = id;
			this.Name = name;
			this.RowVersion = rowVersion;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>850cb9c18020ddaf2a2cc7b512e5ab2a</Hash>
</Codenesium>*/