using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>37aa24680a6b51b6dcd214344e2b6529</Hash>
</Codenesium>*/