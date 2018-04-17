using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class StateModelValidator: AbstractStateModelValidator, IStateModelValidator
	{
		public StateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StateModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StateModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>bc1ac9ee3ff054c24907a182b1c0ab76</Hash>
</Codenesium>*/