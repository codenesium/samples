using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class Studio : AbstractEntity
	{
		public Studio()
		{
		}

		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string name,
			string province,
			string website,
			string zip)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.Province = province;
			this.Website = website;
			this.Zip = zip;
		}

		[MaxLength(128)]
		[Column("address1")]
		public virtual string Address1 { get; private set; }

		[MaxLength(128)]
		[Column("address2")]
		public virtual string Address2 { get; private set; }

		[MaxLength(128)]
		[Column("city")]
		public virtual string City { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[MaxLength(90)]
		[Column("province")]
		public virtual string Province { get; private set; }

		[MaxLength(128)]
		[Column("website")]
		public virtual string Website { get; private set; }

		[MaxLength(128)]
		[Column("zip")]
		public virtual string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f9a31de3ea0a3f5776d7efe65ec596d</Hash>
</Codenesium>*/