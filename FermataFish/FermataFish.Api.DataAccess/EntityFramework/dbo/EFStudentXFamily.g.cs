using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class EFStudentXFamily: AbstractEntityFrameworkPOCO
	{
		public EFStudentXFamily()
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
		public virtual EFFamily Family { get; set; }

		[ForeignKey("StudentId")]
		public virtual EFStudent Student { get; set; }
	}
}

/*<Codenesium>
    <Hash>923bfea68871cadcde2aeeb8dc453b2e</Hash>
</Codenesium>*/