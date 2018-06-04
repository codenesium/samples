using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class BOPaymentType: AbstractBusinessObject
	{
		public BOPaymentType() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7fedc91a4484cd010eaed55dbd039f6f</Hash>
</Codenesium>*/