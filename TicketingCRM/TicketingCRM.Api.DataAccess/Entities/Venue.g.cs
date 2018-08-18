using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Venue", Schema="dbo")]
	public partial class Venue : AbstractEntity
	{
		public Venue()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			int adminId,
			string email,
			string facebook,
			int id,
			string name,
			string phone,
			int provinceId,
			string website)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.AdminId = adminId;
			this.Email = email;
			this.Facebook = facebook;
			this.Id = id;
			this.Name = name;
			this.Phone = phone;
			this.ProvinceId = provinceId;
			this.Website = website;
		}

		[MaxLength(128)]
		[Column("address1")]
		public string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public string Address2 { get; private set; }

		[Column("adminId")]
		public int AdminId { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public string Email { get; private set; }

		[MaxLength(128)]
		[Column("facebook")]
		public string Facebook { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public string Phone { get; private set; }

		[Column("provinceId")]
		public int ProvinceId { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public string Website { get; private set; }

		[ForeignKey("AdminId")]
		public virtual Admin AdminNavigation { get; private set; }

		[ForeignKey("ProvinceId")]
		public virtual Province ProvinceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0fb02d91168a90bfd17514b3c8fd3b84</Hash>
</Codenesium>*/