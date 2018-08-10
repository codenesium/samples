using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("TeacherSkill", Schema="dbo")]
	public partial class TeacherSkill : AbstractEntity
	{
		public TeacherSkill()
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

		[Column("name")]
		public string Name { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e58a47496130a73f8c1399b1d943d070</Hash>
</Codenesium>*/