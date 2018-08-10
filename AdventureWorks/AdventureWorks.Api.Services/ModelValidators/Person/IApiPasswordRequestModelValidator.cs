using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPasswordRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fc86cf900952e5e382bec44997db8265</Hash>
</Codenesium>*/