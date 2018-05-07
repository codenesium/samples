using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IEmployeeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(EmployeeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, EmployeeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8aadad835552fbbf6e1a54d74afce87e</Hash>
</Codenesium>*/