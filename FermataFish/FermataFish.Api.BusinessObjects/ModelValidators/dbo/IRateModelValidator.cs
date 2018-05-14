using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>651b34fd4e33ab7a660f77f0435bee9f</Hash>
</Codenesium>*/