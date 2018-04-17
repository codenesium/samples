using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class LinkLogModelValidator: AbstractLinkLogModelValidator, ILinkLogModelValidator
	{
		public LinkLogModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LinkLogModel model)
		{
			this.LinkIdRules();
			this.LogRules();
			this.DateEnteredRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LinkLogModel model)
		{
			this.LinkIdRules();
			this.LogRules();
			this.DateEnteredRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>02c7d390cdec52a3ba717a0dbf930c8b</Hash>
</Codenesium>*/