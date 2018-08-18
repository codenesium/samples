using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("LessonStatus", Schema="dbo")]
	public partial class LessonStatus : AbstractEntity
	{
		public LessonStatus()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Id = id;
			this.Name = name;
			this.StudioId = studioId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("Id")]
		public virtual Studio StudioNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c7eb298ef35b5c759a472e69c38cb1e8</Hash>
</Codenesium>*/