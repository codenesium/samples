using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Space", Schema="dbo")]
	public partial class EFSpace: AbstractEntityFrameworkPOCO
	{
		public EFSpace()
		{}

		public void SetProperties(
			int id,
			string description,
			string name,
			int studioId)
		{
			this.Description = description.ToString();
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.StudioId = studioId.ToInt();
		}

		[Column("description", TypeName="varchar(128)")]
		public string Description { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>d6d64cc6d847e23f62a5684063e514e2</Hash>
</Codenesium>*/