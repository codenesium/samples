using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>55120d92ef360bf0eaab210cc52bb2e6</Hash>
</Codenesium>*/