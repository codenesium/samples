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
    <Hash>2e45c1a52560349096d944d8719aaa15</Hash>
</Codenesium>*/