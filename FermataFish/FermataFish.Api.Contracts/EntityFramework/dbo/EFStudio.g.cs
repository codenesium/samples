using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("Studio", Schema="dbo")]
	public partial class EFStudio
	{
		public EFStudio()
		{}

		public void SetProperties(
			int id,
			string name,
			string website,
			string address1,
			string address2,
			string city,
			int stateId,
			string zip)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.Website = website;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.StateId = stateId.ToInt();
			this.Zip = zip;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("website", TypeName="varchar(128)")]
		public string Website { get; set; }

		[Column("address1", TypeName="varchar(128)")]
		public string Address1 { get; set; }

		[Column("address2", TypeName="varchar(128)")]
		public string Address2 { get; set; }

		[Column("city", TypeName="varchar(128)")]
		public string City { get; set; }

		[Column("stateId", TypeName="int")]
		public int StateId { get; set; }

		[Column("zip", TypeName="varchar(128)")]
		public string Zip { get; set; }

		[ForeignKey("StateId")]
		public virtual EFState State { get; set; }
	}
}

/*<Codenesium>
    <Hash>92051a40bfdd90b559978e2555905c78</Hash>
</Codenesium>*/