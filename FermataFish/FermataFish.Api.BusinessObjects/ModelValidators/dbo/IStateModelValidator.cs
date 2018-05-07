using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6ccff7a7e574fb66772a6c07066c422a</Hash>
</Codenesium>*/