using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPenRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b44f7b1329ed168b0d6d7b6142fe7699</Hash>
</Codenesium>*/