using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>35dbadabf4395b1507322eb929d6bc19</Hash>
</Codenesium>*/