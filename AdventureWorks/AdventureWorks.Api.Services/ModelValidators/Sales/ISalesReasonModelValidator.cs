using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSalesReasonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fd8dc38663dac7a911c1369427cd0b9e</Hash>
</Codenesium>*/