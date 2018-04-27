using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPetModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PetModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PetModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c9094f81dbe403fa85d1df69c0d80a62</Hash>
</Codenesium>*/