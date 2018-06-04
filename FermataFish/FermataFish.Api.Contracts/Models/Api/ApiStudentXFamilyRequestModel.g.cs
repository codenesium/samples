using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentXFamilyRequestModel: AbstractApiRequestModel
	{
		public ApiStudentXFamilyRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>a978b152f89dae42db8f1f6c182a68f7</Hash>
</Codenesium>*/