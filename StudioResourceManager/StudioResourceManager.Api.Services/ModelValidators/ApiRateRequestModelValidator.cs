using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>3e03f3d97526da22a1d60ff63609c1b7</Hash>
</Codenesium>*/