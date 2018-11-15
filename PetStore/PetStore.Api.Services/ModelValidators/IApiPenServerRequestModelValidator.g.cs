using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPenServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPenServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bd7b2d7440e1791977134116e519a7c8</Hash>
</Codenesium>*/