using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e84ab77e8741d0fd61ae3284a2174704</Hash>
</Codenesium>*/