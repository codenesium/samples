using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("ClientCommunication", Schema="dbo")]
	public partial class ClientCommunication : AbstractEntity
	{
		public ClientCommunication()
		{
		}

		public virtual void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			int id,
			string note)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Note = note;
		}

		[Column("clientId")]
		public int ClientId { get; private set; }

		[Column("dateCreated")]
		public DateTime DateCreated { get; private set; }

		[Column("employeeId")]
		public int EmployeeId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Note { get; private set; }

		[ForeignKey("ClientId")]
		public virtual Client ClientNavigation { get; private set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c9899a6fa48f16f2b95db02cd7003ff5</Hash>
</Codenesium>*/