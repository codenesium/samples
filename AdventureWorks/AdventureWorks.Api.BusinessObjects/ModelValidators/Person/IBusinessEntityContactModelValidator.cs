using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityContactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8af49778b23854864cd758a985987f96</Hash>
</Codenesium>*/