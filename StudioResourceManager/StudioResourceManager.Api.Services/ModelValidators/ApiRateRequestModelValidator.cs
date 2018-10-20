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
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ae7586551a1181c223f3f8c8ee8a494a</Hash>
</Codenesium>*/