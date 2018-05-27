using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStudentXFamilyRequestModelValidator: AbstractApiStudentXFamilyRequestModelValidator, IApiStudentXFamilyRequestModelValidator
	{
		public ApiStudentXFamilyRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model)
		{
			this.FamilyIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model)
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
    <Hash>71c96829c5696cf3c086ef18c316c15b</Hash>
</Codenesium>*/