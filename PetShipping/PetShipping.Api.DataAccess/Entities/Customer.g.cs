using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
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
			string note,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Note = note;
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

		[MaxLength(2147483647)]
		[Column("notes")]
		public virtual string Note { get; private set; }

		[MaxLength(10)]
		[Column("phone")]
		public virtual string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>99320f149a5c162aba2e639f8f5ecafe</Hash>
</Codenesium>*/