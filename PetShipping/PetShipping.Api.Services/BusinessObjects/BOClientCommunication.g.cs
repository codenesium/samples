using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOClientCommunication: AbstractBusinessObject
	{
		public BOClientCommunication() : base()
		{}

		public void SetProperties(int id,
		                          int clientId,
		                          DateTime dateCreated,
		                          int employeeId,
		                          string notes)
		{
			this.ClientId = clientId.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Notes = notes;
		}

		public int ClientId { get; private set; }
		public DateTime DateCreated { get; private set; }
		public int EmployeeId { get; private set; }
		public int Id { get; private set; }
		public string Notes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fddbb95d291906d174aaafd2009c7f4b</Hash>
</Codenesium>*/