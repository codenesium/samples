using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
	public abstract class AbstractBOTimestampCheck : AbstractBusinessObject
	{
		public AbstractBOTimestampCheck()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  byte[] timestamp)
		{
			this.Id = id;
			this.Name = name;
			this.Timestamp = timestamp;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f972b64a7c583a5e7678b169d470e21d</Hash>
</Codenesium>*/