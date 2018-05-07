using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPetModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PetModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PetModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2cd72e9261b6192166c730f92924d809</Hash>
</Codenesium>*/