using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0cbf05223b84969f02927aed544ae656</Hash>
</Codenesium>*/