using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Client", Schema="dbo")]
	public partial class Client:AbstractEntity
	{
		public Client()
		{}

		public void SetProperties(
			string email,
			string firstName,
			int id,
			string lastName,
			string notes,
			string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
		}

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; private set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; private set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; private set; }

		[Column("phone", TypeName="varchar(10)")]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>78a5bc428a8b349f284f42cb64cda5aa</Hash>
</Codenesium>*/