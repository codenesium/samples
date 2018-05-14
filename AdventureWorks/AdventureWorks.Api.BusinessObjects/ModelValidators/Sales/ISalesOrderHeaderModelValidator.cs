using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesOrderHeaderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>95f5cb844bc2430310b0632137690fda</Hash>
</Codenesium>*/