using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOEmployee: AbstractBusinessObject
	{
		public BOEmployee() : base()
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

		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public bool IsSalesPerson { get; private set; }
		public bool IsShipper { get; private set; }
		public string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>04bd2a774c8710a900519aa3f05b6d18</Hash>
</Codenesium>*/