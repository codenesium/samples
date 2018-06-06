using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherSkill", Schema="dbo")]
	public partial class TeacherSkill: AbstractEntity
	{
		public TeacherSkill()
		{}

		public void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>25557467cf12026cdc7e53e4dfabcef2</Hash>
</Codenesium>*/