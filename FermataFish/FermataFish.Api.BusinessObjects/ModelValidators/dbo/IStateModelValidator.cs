using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b9f8dbbfe9a0d1d62f349f8572d98ed2</Hash>
</Codenesium>*/