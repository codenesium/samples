using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiTeacherSkillRequestModelValidator: AbstractApiTeacherSkillRequestModelValidator, IApiTeacherSkillRequestModelValidator
	{
		public ApiTeacherSkillRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>acb96dca5bfbb4adba69e46433ea3d2c</Hash>
</Codenesium>*/