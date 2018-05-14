using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiTeacherSkillModelValidator: AbstractApiTeacherSkillModelValidator, IApiTeacherSkillModelValidator
	{
		public ApiTeacherSkillModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillModel model)
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
    <Hash>abcfc8047512b698602deae0ca369be4</Hash>
</Codenesium>*/