using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStoreRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eb1fcabc6c04378e60eafcc47757be99</Hash>
</Codenesium>*/