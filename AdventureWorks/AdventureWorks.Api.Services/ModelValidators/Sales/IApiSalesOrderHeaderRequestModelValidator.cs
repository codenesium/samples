using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1520799c12cc8aab79e494a8968d6abc</Hash>
</Codenesium>*/