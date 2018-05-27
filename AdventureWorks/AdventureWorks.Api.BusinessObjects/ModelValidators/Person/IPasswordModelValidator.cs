using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPasswordRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bd806cce33e307982be18b85d6fee2b3</Hash>
</Codenesium>*/