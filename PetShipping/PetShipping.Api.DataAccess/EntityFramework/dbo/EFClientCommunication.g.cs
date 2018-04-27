using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("ClientCommunication", Schema="dbo")]
	public partial class EFClientCommunication: AbstractEntityFrameworkPOCO
	{
		public EFClientCommunication()
		{}

		public void SetProperties(
			int id,
			int clientId,
			DateTime dateCreated,
			int employeeId,
			string notes)
		{
			this.ClientId = clientId.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Notes = notes.ToString();
		}

		[Column("clientId", TypeName="int")]
		public int ClientId { get; set; }

		[Column("dateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; set; }

		[Column("employeeId", TypeName="int")]
		public int EmployeeId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; set; }

		[ForeignKey("ClientId")]
		public virtual EFClient Client { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>2c3c52b185e3ce1422b89c319e15fee9</Hash>
</Codenesium>*/