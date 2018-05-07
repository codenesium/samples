using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPenModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PenModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PenModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cc4ba567bee7ad46392566efa80896c0</Hash>
</Codenesium>*/