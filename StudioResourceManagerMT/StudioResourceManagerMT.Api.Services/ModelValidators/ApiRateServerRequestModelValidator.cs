using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiRateServerRequestModelValidator : AbstractApiRateServerRequestModelValidator, IApiRateServerRequestModelValidator
	{
		public ApiRateServerRequestModelValidator(IRateRepository rateRepository)
			: base(rateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRateServerRequestModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateServerRequestModel model)
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
    <Hash>d6fe1198c53331f4d0d7c6a198fb9ba9</Hash>
</Codenesium>*/