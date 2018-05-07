using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(RateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, RateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3cb371c66596a59bd7162333b4a27f40</Hash>
</Codenesium>*/