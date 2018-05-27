using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOEmployee: AbstractDTO
	{
		public DTOEmployee() : base()
		{}

		public void SetProperties(int id,
		                          string firstName,
		                          bool isSalesPerson,
		                          bool isShipper,
		                          string lastName)
		{
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName;
		}

		public string FirstName { get; set; }
		public int Id { get; set; }
		public bool IsSalesPerson { get; set; }
		public bool IsShipper { get; set; }
		public string LastName { get; set; }
	}
}

/*<Codenesium>
    <Hash>315b313686f73e7c739d86668a2d8aa0</Hash>
</Codenesium>*/