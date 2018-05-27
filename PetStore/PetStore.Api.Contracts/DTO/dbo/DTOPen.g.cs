using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class DTOPen:AbstractDTO
	{
		public DTOPen() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>d0811f46a2def846d839acad577ae8cc</Hash>
</Codenesium>*/