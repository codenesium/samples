using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiChainRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>885b45a948dcf36f175309a31b1ef5c2</Hash>
</Codenesium>*/