using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonStatus", Schema="dbo")]
	public partial class EFLessonStatus: AbstractEntityFrameworkPOCO
	{
		public EFLessonStatus()
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
		public virtual EFStudio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>e1d5ebfd1fc661cf85ada75039c0c07a</Hash>
</Codenesium>*/