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
		public virtual int ClientId { get; private set; }

		[Column("dateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[Column("employeeId")]
		public virtual int EmployeeId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public virtual string Note { get; private set; }

		[ForeignKey("ClientId")]
		public virtual Client ClientNavigation { get; private set; }

		public void SetClientNavigation(Client item)
		{
			this.ClientNavigation = item;
		}

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeNavigation { get; private set; }

		public void SetEmployeeNavigation(Employee item)
		{
			this.EmployeeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>148c8c9a551b8566dc376b17923dc622</Hash>
</Codenesium>*/