using System;
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
    <Hash>25eaf98ab1f7b8a0bf91a363b19938e8</Hash>
</Codenesium>*/