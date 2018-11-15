using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Customer", Schema="dbo")]
	public partial class Customer : AbstractEntity
	{
		public Customer()
		{
		}

		public virtual void SetProperties(
			string email,
			string firstName,
			int id,
			string lastName,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[MaxLength(128)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public virtual string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ca80ba59819f6d2a0b0cb7625c6fccc2</Hash>
</Codenesium>*/