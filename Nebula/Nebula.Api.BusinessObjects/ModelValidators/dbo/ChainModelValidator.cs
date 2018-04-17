using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ChainModelValidator: AbstractChainModelValidator, IChainModelValidator
	{
		public ChainModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ChainModel model)
		{
			this.NameRules();
			this.TeamIdRules();
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ChainModel model)
		{
			this.NameRules();
			this.TeamIdRules();
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5a44803ee57839d27117f1793cb94baa</Hash>
</Codenesium>*/