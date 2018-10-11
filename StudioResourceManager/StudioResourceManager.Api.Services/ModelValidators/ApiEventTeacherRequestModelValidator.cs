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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherRequestModel model)
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
    <Hash>14c97172b11d65bc8e90707ba13772c9</Hash>
</Codenesium>*/