using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonStatus", Schema="dbo")]
	public partial class LessonStatus: AbstractEntityFrameworkPOCO
	{
		public LessonStatus()
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

		[ForeignKey("Id")]
		public virtual Studio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>8912af9cbbbd6ba734d1824a3949cc25</Hash>
</Codenesium>*/