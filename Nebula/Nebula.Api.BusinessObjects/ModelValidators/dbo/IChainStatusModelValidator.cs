using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiChainStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3af4097111d4a60973de98445761e8e3</Hash>
</Codenesium>*/