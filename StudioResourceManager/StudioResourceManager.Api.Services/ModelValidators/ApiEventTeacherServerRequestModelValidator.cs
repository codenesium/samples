using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventTeacherServerRequestModelValidator : AbstractApiEventTeacherServerRequestModelValidator, IApiEventTeacherServerRequestModelValidator
	{
		public ApiEventTeacherServerRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
			: base(eventTeacherRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherServerRequestModel model)
		{
			this.EventIdRules();
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model)
		{
			this.EventIdRules();
			this.TeacherIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>840aa429aaeb113bc9eb66ef3f972d70</Hash>
</Codenesium>*/