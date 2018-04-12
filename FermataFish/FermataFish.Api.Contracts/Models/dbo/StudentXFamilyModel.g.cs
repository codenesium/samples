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
			int studentId,
			int familyId)
		{
			this.StudentId = studentId.ToInt();
			this.FamilyId = familyId.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>e699eedf569c73b7b42277a8eb4bcc71</Hash>
</Codenesium>*/