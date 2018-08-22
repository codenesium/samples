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
    <Hash>8e561ade631e3c268c0c80383ac8413f</Hash>
</Codenesium>*/