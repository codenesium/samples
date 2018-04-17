using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ChainStatusModelValidator: AbstractChainStatusModelValidator, IChainStatusModelValidator
	{
		public ChainStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ChainStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ChainStatusModel model)
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
    <Hash>1fa333e1851469206d673853abb277b8</Hash>
</Codenesium>*/