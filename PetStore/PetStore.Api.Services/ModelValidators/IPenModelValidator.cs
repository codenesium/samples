using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
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
    <Hash>3c163cd6ecf1701f225e293b7da9b55e</Hash>
</Codenesium>*/