using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("StudentXFamily", Schema="dbo")]
	public partial class EFStudentXFamily
	{
		public EFStudentXFamily()
		{}

		public void SetProperties(
			int id,
			int studentId,
			int familyId)
		{
			this.Id = id.ToInt();
			this.StudentId = studentId.ToInt();
			this.FamilyId = familyId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("studentId", TypeName="int")]
		public int StudentId { get; set; }

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; set; }

		[ForeignKey("StudentId")]
		public virtual EFStudent Student { get; set; }

		[ForeignKey("FamilyId")]
		public virtual EFFamily Family { get; set; }
	}
}

/*<Codenesium>
    <Hash>83032e0af7169ad2393e04a137591b84</Hash>
</Codenesium>*/