using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IChainStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ChainStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ChainStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac5b2aa948a868df6f7eb533cbc00c91</Hash>
</Codenesium>*/