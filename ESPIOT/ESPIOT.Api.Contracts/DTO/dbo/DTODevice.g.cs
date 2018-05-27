using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace ESPIOTNS.Api.Contracts
{
	public partial class DTODevice: AbstractDTO
	{
		public DTODevice() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId.ToGuid();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Guid PublicId { get; set; }
	}
}

/*<Codenesium>
    <Hash>cfdf5d6ce2efb089441b4aa9015f3308</Hash>
</Codenesium>*/