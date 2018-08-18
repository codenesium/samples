using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class Studio : AbstractEntity
	{
		public Studio()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			string city,
			int id,
			string name,
			int stateId,
			string website,
			string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id;
			this.Name = name;
			this.StateId = stateId;
			this.Website = website;
			this.Zip = zip;
		}

		[MaxLength(128)]
		[Column("address1")]
		public string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public string Address2 { get; private set; }

		[MaxLength(128)]
		[Column("city")]
		public string City { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("stateId")]
		public int StateId { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public string Website { get; private set; }

		[MaxLength(128)]
		[Column("zip")]
		public string Zip { get; private set; }

		[ForeignKey("StateId")]
		public virtual State StateNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5a68d0f029db4cf7fa9848d5995f5b55</Hash>
</Codenesium>*/