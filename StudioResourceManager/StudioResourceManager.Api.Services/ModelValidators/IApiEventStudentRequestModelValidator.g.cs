using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStudentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>43769f5691bf577dfa2fd0dd7a090004</Hash>
</Codenesium>*/