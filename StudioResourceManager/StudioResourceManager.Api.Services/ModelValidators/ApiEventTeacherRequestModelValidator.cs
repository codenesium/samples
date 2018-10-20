using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventTeacherRequestModelValidator : AbstractApiEventTeacherRequestModelValidator, IApiEventTeacherRequestModelValidator
	{
		public ApiEventTeacherRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
			: base(eventTeacherRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherRequestModel model)
		{
			this.TeacherIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherRequestModel model)
		{
			this.TeacherIdRules();
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
    <Hash>1ef870923c8c793b6ae0e6f3e1a0632d</Hash>
</Codenesium>*/