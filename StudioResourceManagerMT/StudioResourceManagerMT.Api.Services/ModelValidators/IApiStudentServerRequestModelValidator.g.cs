using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiStudentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>736e515e66f5558c17903aea2f045b5a</Hash>
</Codenesium>*/