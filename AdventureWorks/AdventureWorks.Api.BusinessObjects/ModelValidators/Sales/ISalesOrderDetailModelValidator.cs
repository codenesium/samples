using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesOrderDetailModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b9a6df40d775e9d2b63a7b16b6e1d239</Hash>
</Codenesium>*/