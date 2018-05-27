using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmployeeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>effe6eb3357f22d37f9f88ffbf6bf078</Hash>
</Codenesium>*/