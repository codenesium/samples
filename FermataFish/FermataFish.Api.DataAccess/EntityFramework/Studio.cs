using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class Studio:AbstractEntity
	{
		public Studio()
		{}

		public void SetProperties(
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
			this.Id = id.ToInt();
			this.Name = name;
			this.StateId = stateId.ToInt();
			this.Website = website;
			this.Zip = zip;
		}

		[Column("address1", TypeName="varchar(128)")]
		public string Address1 { get; private set; }

		[Column("address2", TypeName="varchar(128)")]
		public string Address2 { get; private set; }

		[Column("city", TypeName="varchar(128)")]
		public string City { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("stateId", TypeName="int")]
		public int StateId { get; private set; }

		[Column("website", TypeName="varchar(128)")]
		public string Website { get; private set; }

		[Column("zip", TypeName="varchar(128)")]
		public string Zip { get; private set; }

		[ForeignKey("StateId")]
		public virtual State State { get; set; }
	}
}

/*<Codenesium>
    <Hash>e95dae82bacfd90ef96959b8a1e9e270</Hash>
</Codenesium>*/