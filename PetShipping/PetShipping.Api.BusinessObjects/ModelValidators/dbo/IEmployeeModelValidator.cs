using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IEmployeeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(EmployeeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, EmployeeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fdde3a41850c98245162aeacce6f3fb7</Hash>
</Codenesium>*/