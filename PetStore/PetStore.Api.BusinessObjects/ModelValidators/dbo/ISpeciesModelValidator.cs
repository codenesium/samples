using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiSpeciesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9ce09db0774882dd3409c5d10bfb10de</Hash>
</Codenesium>*/