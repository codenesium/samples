using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("ClientCommunication", Schema="dbo")]
	public partial class ClientCommunication: AbstractEntity
	{
		public ClientCommunication()
		{}

		public void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			int id,
			string notes)
		{
			this.ClientId = clientId.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Notes = notes;
		}

		[Column("clientId", TypeName="int")]
		public int ClientId { get; private set; }

		[Column("dateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; private set; }

		[Column("employeeId", TypeName="int")]
		public int EmployeeId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; private set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>8afa8849e8b7fa9d3ee384d54fc5c886</Hash>
</Codenesium>*/