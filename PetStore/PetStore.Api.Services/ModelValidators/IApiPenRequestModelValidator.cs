using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public interface IApiPenRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>01a528fd13de1398b2c55f1b4f31da9a</Hash>
</Codenesium>*/