using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiStudentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>63e81a8f19599a7415beae35e477d320</Hash>
</Codenesium>*/