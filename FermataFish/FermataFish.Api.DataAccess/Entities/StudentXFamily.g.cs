using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class StudentXFamily : AbstractEntity
	{
		public StudentXFamily()
		{
		}

		public virtual void SetProperties(
			int id,
			int familyId,
			int studentId,
			int studioId)
		{
			this.Id = id;
			this.FamilyId = familyId;
			this.StudentId = studentId;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("familyId")]
		public int FamilyId { get; private set; }

		[Column("studentId")]
		public int StudentId { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("FamilyId")]
		public virtual Family FamilyNavigation { get; private set; }

		[ForeignKey("StudentId")]
		public virtual Student StudentNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>15d5b88d75864a148f1b368f65588d81</Hash>
</Codenesium>*/