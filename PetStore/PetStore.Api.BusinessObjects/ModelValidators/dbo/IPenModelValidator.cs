using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPenModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPenModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5d4bb285a16c3b6567900a2001cd2e00</Hash>
</Codenesium>*/