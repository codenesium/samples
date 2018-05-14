using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiSpeciesModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa094974b0591d765ca33bce03e70ac0</Hash>
</Codenesium>*/