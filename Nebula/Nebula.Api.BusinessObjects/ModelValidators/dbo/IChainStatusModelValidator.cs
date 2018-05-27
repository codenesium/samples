using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiChainStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>409ef660f45d188f439e5f6d134caec6</Hash>
</Codenesium>*/