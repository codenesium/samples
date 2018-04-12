using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("Space", Schema="dbo")]
	public partial class EFSpace
	{
		public EFSpace()
		{}

		public void SetProperties(
			int id,
			string name,
			string description,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.Description = description;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("description", TypeName="varchar(128)")]
		public string Description { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>eff0b23828baeea3a4ff41db3182d128</Hash>
</Codenesium>*/