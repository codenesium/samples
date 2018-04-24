using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Studio", Schema="dbo")]
	public partial class EFStudio: AbstractEntityFrameworkPOCO
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
			this.Name = name.ToString();
			this.Website = website.ToString();
			this.Address1 = address1.ToString();
			this.Address2 = address2.ToString();
			this.City = city.ToString();
			this.StateId = stateId.ToInt();
			this.Zip = zip.ToString();
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
    <Hash>6488c546d0cbde14a78ea8127be93d4e</Hash>
</Codenesium>*/