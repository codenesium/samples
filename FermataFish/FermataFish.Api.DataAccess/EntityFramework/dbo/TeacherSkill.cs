using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherSkill", Schema="dbo")]
	public partial class TeacherSkill: AbstractEntityFrameworkPOCO
	{
		public TeacherSkill()
		{}

		public void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.StudioId = studioId.ToInt();
		}

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
    <Hash>aaa2d3b907acaa3f3a4ffee527c8b81e</Hash>
</Codenesium>*/