using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductListPriceHistoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductListPriceHistoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductListPriceHistoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2c35bee09a6fc4b0826f0a8bc03fd94c</Hash>
</Codenesium>*/