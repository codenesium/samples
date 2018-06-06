using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
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
    <Hash>04a3b02689b5e647b311904220fc4d39</Hash>
</Codenesium>*/