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
    <Hash>999e550fe852a5cead220f3b89d788cc</Hash>
</Codenesium>*/