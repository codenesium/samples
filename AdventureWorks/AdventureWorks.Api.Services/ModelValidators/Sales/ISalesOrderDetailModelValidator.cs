using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>64924f497ddd546ed34073d087636a2e</Hash>
</Codenesium>*/