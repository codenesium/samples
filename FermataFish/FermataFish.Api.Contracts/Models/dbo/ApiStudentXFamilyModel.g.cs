using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyModel
	{
		public ApiStudentXFamilyModel()
		{}

		public ApiStudentXFamilyModel(
			int familyId,
			int studentId)
		{
			this.FamilyId = familyId.ToInt();
			this.StudentId = studentId.ToInt();
		}

		private int familyId;

		[Required]
		public int FamilyId
		{
			get
			{
				return this.familyId;
			}

			set
			{
				this.familyId = value;
			}
		}

		private int studentId;

		[Required]
		public int StudentId
		{
			get
			{
				return this.studentId;
			}

			set
			{
				this.studentId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>2666c67cc605ac9daae6075a875fbb19</Hash>
</Codenesium>*/