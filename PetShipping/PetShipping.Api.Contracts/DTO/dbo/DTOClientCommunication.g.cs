using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOClientCommunication: AbstractDTO
	{
		public DTOClientCommunication() : base()
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

		public int ClientId { get; set; }
		public DateTime DateCreated { get; set; }
		public int EmployeeId { get; set; }
		public int Id { get; set; }
		public string Notes { get; set; }
	}
}

/*<Codenesium>
    <Hash>b56aabea55537f546833c05591a0384d</Hash>
</Codenesium>*/