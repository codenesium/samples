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
		public virtual string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public virtual string Address2 { get; private set; }

		[Column("adminId")]
		public virtual int AdminId { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[MaxLength(128)]
		[Column("facebook")]
		public virtual string Facebook { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public virtual string Phone { get; private set; }

		[Column("provinceId")]
		public virtual int ProvinceId { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public virtual string Website { get; private set; }

		[ForeignKey("AdminId")]
		public virtual Admin AdminNavigation { get; private set; }

		public void SetAdminNavigation(Admin item)
		{
			this.AdminNavigation = item;
		}

		[ForeignKey("ProvinceId")]
		public virtual Province ProvinceNavigation { get; private set; }

		public void SetProvinceNavigation(Province item)
		{
			this.ProvinceNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>50573f9b9b4cad68e23d64645e09ca85</Hash>
</Codenesium>*/