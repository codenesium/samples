using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmailAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c05474fd527dff64b80fd2f26b0594ec</Hash>
</Codenesium>*/