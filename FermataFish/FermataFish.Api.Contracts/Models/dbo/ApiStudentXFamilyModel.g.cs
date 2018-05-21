using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyModel: AbstractModel
	{
		public ApiStudentXFamilyModel() : base()
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
    <Hash>35b37011247b110f02644308e84f26a4</Hash>
</Codenesium>*/