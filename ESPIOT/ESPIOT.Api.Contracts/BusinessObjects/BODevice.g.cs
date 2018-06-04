using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class BODevice: AbstractBusinessObject
	{
		public BODevice() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>aa1edb39840723d533fec0c3370d37f0</Hash>
</Codenesium>*/