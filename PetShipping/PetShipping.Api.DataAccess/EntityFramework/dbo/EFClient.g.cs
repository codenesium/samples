using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Client", Schema="dbo")]
	public partial class EFClient: AbstractEntityFrameworkPOCO
	{
		public EFClient()
		{}

		public void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string notes,
			string phone)
		{
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.LastName = lastName.ToString();
			this.Notes = notes.ToString();
			this.Phone = phone.ToString();
		}

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; set; }

		[Column("phone", TypeName="varchar(10)")]
		public string Phone { get; set; }
	}
}

/*<Codenesium>
    <Hash>d5064beae0aad95b0fa64fbdbddd64df</Hash>
</Codenesium>*/