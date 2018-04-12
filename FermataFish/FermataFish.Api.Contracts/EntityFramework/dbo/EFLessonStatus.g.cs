using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("LessonStatus", Schema="dbo")]
	public partial class EFLessonStatus
	{
		public EFLessonStatus()
		{}

		public void SetProperties(
			string name,
			int id,
			int studioId)
		{
			this.Name = name;
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
    <Hash>6a3322f09ac3630da08db86c00611801</Hash>
</Codenesium>*/