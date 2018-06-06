using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Family", Schema="dbo")]
	public partial class Family:AbstractEntity
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
			this.Notes = notes;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("notes", TypeName="text(2147483647)")]
		public string Notes { get; private set; }

		[Column("pcEmail", TypeName="varchar(128)")]
		public string PcEmail { get; private set; }

		[Column("pcFirstName", TypeName="varchar(128)")]
		public string PcFirstName { get; private set; }

		[Column("pcLastName", TypeName="varchar(128)")]
		public string PcLastName { get; private set; }

		[Column("pcPhone", TypeName="varchar(128)")]
		public string PcPhone { get; private set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; private set; }

		[ForeignKey("Id")]
		public virtual Studio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>a0e9b05e2e4095e2e71141b90c949570</Hash>
</Codenesium>*/