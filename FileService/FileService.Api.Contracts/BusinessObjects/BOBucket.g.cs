using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class BOBucket: AbstractBusinessObject
	{
		public BOBucket() : base()
		{}

		public void SetProperties(int id,
		                          Guid externalId,
		                          string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
		}

		public Guid ExternalId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c4ca1563834db99c888c9a3792a95006</Hash>
</Codenesium>*/