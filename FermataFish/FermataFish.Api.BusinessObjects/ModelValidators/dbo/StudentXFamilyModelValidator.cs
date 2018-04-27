using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class StudentXFamilyModelValidator: AbstractStudentXFamilyModelValidator, IStudentXFamilyModelValidator
	{
		public StudentXFamilyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StudentXFamilyModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StudentXFamilyModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>55feb2265b54b40a47ea7914732f6b4f</Hash>
</Codenesium>*/