using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiRateModelValidator: AbstractApiRateModelValidator, IApiRateModelValidator
	{
		public ApiRateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiRateModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7a3f98a0cbb6c4918dfbd69a40709ce0</Hash>
</Codenesium>*/