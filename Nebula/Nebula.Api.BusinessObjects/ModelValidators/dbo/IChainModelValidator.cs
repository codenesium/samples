using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IChainModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ChainModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ChainModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e86ef4ea8757859d28cdd4e15ab5d99c</Hash>
</Codenesium>*/