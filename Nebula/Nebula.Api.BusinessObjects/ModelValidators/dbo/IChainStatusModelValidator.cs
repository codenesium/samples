using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IChainStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ChainStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ChainStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>73c6af225277f8c8fd9f00e128725513</Hash>
</Codenesium>*/