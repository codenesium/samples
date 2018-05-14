using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Handler", Schema="dbo")]
	public partial class Handler: AbstractEntityFrameworkPOCO
	{
		public Handler()
		{}

		public void SetProperties(
			int id,
			int countryId,
			string email,
			string firstName,
			string lastName,
			string phone)
		{
			this.CountryId = countryId.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
		}

		[Column("countryId", TypeName="int")]
		public int CountryId { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("phone", TypeName="varchar(10)")]
		public string Phone { get; set; }
	}
}

/*<Codenesium>
    <Hash>9642414ab249b6388274bb6031373465</Hash>
</Codenesium>*/