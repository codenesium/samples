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
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model)
		{
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
    <Hash>1500fb3267c7d09a32298f6ab337983f</Hash>
</Codenesium>*/