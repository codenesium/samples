using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Handler", Schema="dbo")]
	public partial class Handler : AbstractEntity
	{
		public Handler()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string email,
			string firstName,
			int id,
			string lastName,
			string phone)
		{
			this.CountryId = countryId;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
		}

		[Column("countryId")]
		public int CountryId { get; private set; }

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

		[MaxLength(10)]
		[Column("phone")]
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>11c1718204503686df97f7b74dc8fd80</Hash>
</Codenesium>*/