using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Family", Schema="dbo")]
	public partial class Family:AbstractEntityFrameworkPOCO
	{
		public Family()
		{}

		public void SetProperties(
			int id,
			string notes,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Notes = notes.ToString();
			this.PcEmail = pcEmail.ToString();
			this.PcFirstName = pcFirstName.ToString();
			this.PcLastName = pcLastName.ToString();
			this.PcPhone = pcPhone.ToString();
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; set; }

		[Column("pcEmail", TypeName="varchar(128)")]
		public string PcEmail { get; set; }

		[Column("pcFirstName", TypeName="varchar(128)")]
		public string PcFirstName { get; set; }

		[Column("pcLastName", TypeName="varchar(128)")]
		public string PcLastName { get; set; }

		[Column("pcPhone", TypeName="varchar(128)")]
		public string PcPhone { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("Id")]
		public virtual Studio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>b67a9710e3f89cc0ee9aff0d9e1255fb</Hash>
</Codenesium>*/