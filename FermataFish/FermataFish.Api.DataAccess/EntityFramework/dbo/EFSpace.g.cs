using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Space", Schema="dbo")]
	public partial class Space:AbstractEntityFrameworkPOCO
	{
		public Space()
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
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>aab9c0fe506551962734101848ffea79</Hash>
</Codenesium>*/