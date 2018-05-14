using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class StudentXFamily: AbstractEntityFrameworkPOCO
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
    <Hash>2da4335f6f79336006774b57429b10e0</Hash>
</Codenesium>*/