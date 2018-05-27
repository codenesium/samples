using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiContactTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bfa4636a424f8adf95000695a29b5a94</Hash>
</Codenesium>*/