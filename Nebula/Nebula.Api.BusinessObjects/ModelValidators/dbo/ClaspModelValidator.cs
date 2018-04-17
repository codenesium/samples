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
			this.PreviousChainIdRules();
			this.NextChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ClaspModel model)
		{
			this.PreviousChainIdRules();
			this.NextChainIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7cd0ba938fd73c6fa4580d32db991ec8</Hash>
</Codenesium>*/