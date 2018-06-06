using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonStatus", Schema="dbo")]
	public partial class LessonStatus: AbstractEntity
	{
		public LessonStatus()
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

		[ForeignKey("Id")]
		public virtual Studio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>3f9ed7622d3f3ce288fa551bc22e9341</Hash>
</Codenesium>*/