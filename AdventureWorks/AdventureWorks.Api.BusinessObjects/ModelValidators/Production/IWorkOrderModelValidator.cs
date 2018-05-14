using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiWorkOrderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>11f4d970356f9bbee4e78750e0d5b6bc</Hash>
</Codenesium>*/