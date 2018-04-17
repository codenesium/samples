using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IChainModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ChainModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ChainModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dfe38ea30efc7cab82340b1ad8071d4a</Hash>
</Codenesium>*/