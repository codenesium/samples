using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class Studio:AbstractEntityFrameworkPOCO
	{
		public Studio()
		{}

		public void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string name,
			int stateId,
			string website,
			string zip)
		{
			this.Address1 = address1.ToString();
			this.Address2 = address2.ToString();
			this.City = city.ToString();
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.StateId = stateId.ToInt();
			this.Website = website.ToString();
			this.Zip = zip.ToString();
		}

		[Column("address1", TypeName="varchar(128)")]
		public string Address1 { get; set; }

		[Column("address2", TypeName="varchar(128)")]
		public string Address2 { get; set; }

		[Column("city", TypeName="varchar(128)")]
		public string City { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("stateId", TypeName="int")]
		public int StateId { get; set; }

		[Column("website", TypeName="varchar(128)")]
		public string Website { get; set; }

		[Column("zip", TypeName="varchar(128)")]
		public string Zip { get; set; }

		[ForeignKey("StateId")]
		public virtual State State { get; set; }
	}
}

/*<Codenesium>
    <Hash>80820ef8f23a6115262749f077f1d17a</Hash>
</Codenesium>*/