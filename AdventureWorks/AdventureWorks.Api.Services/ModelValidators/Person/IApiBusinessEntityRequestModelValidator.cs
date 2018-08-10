using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>37c1aa9d61fdd385dafb07423dfec588</Hash>
</Codenesium>*/