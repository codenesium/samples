using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesPersonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd406bb23098a754573589b913fb2fe7</Hash>
</Codenesium>*/