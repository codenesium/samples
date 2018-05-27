using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d86858823128c18b5e1e172060bd0e42</Hash>
</Codenesium>*/