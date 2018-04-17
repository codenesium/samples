using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class RateModelValidator: AbstractRateModelValidator, IRateModelValidator
	{
		public RateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(RateModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherSkillIdRules();
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, RateModel model)
		{
			this.AmountPerMinuteRules();
			this.TeacherSkillIdRules();
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>59e45c479ce67d568539ccccfd97c876</Hash>
</Codenesium>*/