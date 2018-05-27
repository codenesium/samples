using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class DTOBucket: AbstractDTO
	{
		public DTOBucket() : base()
		{}

		public void SetProperties(int id,
		                          Guid externalId,
		                          string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
		}

		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>9367c2f5690d0fd9090e3fcf656df864</Hash>
</Codenesium>*/