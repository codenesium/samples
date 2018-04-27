using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class StudentXFamilyModel
	{
		public StudentXFamilyModel()
		{}

		public StudentXFamilyModel(
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
    <Hash>531e0d1d81594aaeaf5bf0d188e459ab</Hash>
</Codenesium>*/