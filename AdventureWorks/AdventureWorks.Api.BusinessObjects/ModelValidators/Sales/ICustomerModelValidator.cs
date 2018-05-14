using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCustomerModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>467d002b8e4eb6de8c6a637069a5e210</Hash>
</Codenesium>*/