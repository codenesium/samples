using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventStudentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStudentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bb429f354e95d73f16ac4fdad4d299db</Hash>
</Codenesium>*/