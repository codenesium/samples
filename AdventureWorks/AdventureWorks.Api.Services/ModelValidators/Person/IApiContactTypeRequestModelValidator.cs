using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiContactTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a65a1e66516f2621cd3775e23581efe5</Hash>
</Codenesium>*/