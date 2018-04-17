using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmployeeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(EmployeeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, EmployeeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ba15ce9b4e30df1b0a56126afa6950ba</Hash>
</Codenesium>*/