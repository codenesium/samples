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
			this.Name = name.ToString();
			this.Id = id.ToInt();
			this.StudioId = studioId.ToInt();
		}

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("Id")]
		public virtual EFStudio Studio { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>eb383d8d59831476081619f38a3ea93d</Hash>
</Codenesium>*/