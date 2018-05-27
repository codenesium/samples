using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductInventoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c12e50049284fa6f2aa0f8a167a80a02</Hash>
</Codenesium>*/