using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Client", Schema="dbo")]
	public partial class Client : AbstractEntity
	{
		public Client()
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
		public string Email { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public string LastName { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Note { get; private set; }

		[MaxLength(10)]
		[Column("phone")]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f075872dfbcdd7b9d2de375b109aa732</Hash>
</Codenesium>*/