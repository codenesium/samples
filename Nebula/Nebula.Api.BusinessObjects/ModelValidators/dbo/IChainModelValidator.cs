using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiChainModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eea914757872efc63bbff3b7c2a93851</Hash>
</Codenesium>*/