using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class StudentXFamily: AbstractEntity
	{
		public StudentXFamily()
		{}

		public void SetProperties(
			int familyId,
			int id,
			int studentId)
		{
			this.FamilyId = familyId.ToInt();
			this.Id = id.ToInt();
			this.StudentId = studentId.ToInt();
		}

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; private set; }

		[ForeignKey("FamilyId")]
		public virtual Family Family { get; set; }

		[ForeignKey("StudentId")]
		public virtual Student Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>ca0c4a5ece82eb512a080e618b631ea9</Hash>
</Codenesium>*/