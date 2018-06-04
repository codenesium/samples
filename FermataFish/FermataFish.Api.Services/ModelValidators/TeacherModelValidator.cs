using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiTeacherRequestModelValidator: AbstractApiTeacherRequestModelValidator, IApiTeacherRequestModelValidator
	{
		public ApiTeacherRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model)
		{
			this.BirthdayRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>3793cbca29545de5237b6cb3d6665fca</Hash>
</Codenesium>*/