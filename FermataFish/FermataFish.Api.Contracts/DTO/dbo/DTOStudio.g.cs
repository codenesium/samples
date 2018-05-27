using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOStudio: AbstractDTO
	{
		public DTOStudio() : base()
		{}

		public void SetProperties(int id,
		                          string address1,
		                          string address2,
		                          string city,
		                          string name,
		                          int stateId,
		                          string website,
		                          string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id.ToInt();
			this.Name = name;
			this.StateId = stateId.ToInt();
			this.Website = website;
			this.Zip = zip;
		}

		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int StateId { get; set; }
		public string Website { get; set; }
		public string Zip { get; set; }
	}
}

/*<Codenesium>
    <Hash>a198311a633572fc557ff25ce919ba19</Hash>
</Codenesium>*/