using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiTeacherRequestModelValidator : AbstractApiTeacherRequestModelValidator, IApiTeacherRequestModelValidator
	{
		public ApiTeacherRequestModelValidator(ITeacherRepository teacherRepository)
			: base(teacherRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7f5ee66176e9b69f37f4efc725173133</Hash>
</Codenesium>*/