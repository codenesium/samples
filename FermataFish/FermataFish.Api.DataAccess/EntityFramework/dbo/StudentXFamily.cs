using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class StudentXFamily: AbstractEntityFrameworkDTO
	{
		public StudentXFamily()
		{}

		public void SetProperties(
			int id,
			int familyId,
			int studentId)
		{
			this.FamilyId = familyId.ToInt();
			this.Id = id.ToInt();
			this.StudentId = studentId.ToInt();
		}

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; set; }

		[ForeignKey("FamilyId")]
		public virtual Family Family { get; set; }

		[ForeignKey("StudentId")]
		public virtual Student Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>8c2e3a7b797d6494a667362687929f16</Hash>
</Codenesium>*/