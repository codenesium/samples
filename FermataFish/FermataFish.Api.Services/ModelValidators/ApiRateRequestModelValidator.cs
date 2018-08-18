using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiRateRequestModelValidator : AbstractApiRateRequestModelValidator, IApiRateRequestModelValidator
	{
		public ApiRateRequestModelValidator(IRateRepository rateRepository)
			: base(rateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>65ce4254e8feee8b5979318aee42e865</Hash>
</Codenesium>*/