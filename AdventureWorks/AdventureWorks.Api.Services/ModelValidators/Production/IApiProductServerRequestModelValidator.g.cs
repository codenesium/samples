using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f613f183ba2b222069d83c80eb510667</Hash>
</Codenesium>*/