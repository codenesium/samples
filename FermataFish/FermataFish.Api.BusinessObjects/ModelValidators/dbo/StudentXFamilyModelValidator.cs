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
			this.StudentIdRules();
			this.FamilyIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StudentXFamilyModel model)
		{
			this.StudentIdRules();
			this.FamilyIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>33762e7094ad462d30a0d7b54940db67</Hash>
</Codenesium>*/