using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ClaspModelValidator: AbstractClaspModelValidator, IClaspModelValidator
	{
		public ClaspModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ClaspModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ClaspModel model)
		{
			this.NextChainIdRules();
			this.PreviousChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>33d0eb86020b169ddb542b47c97b73b5</Hash>
</Codenesium>*/