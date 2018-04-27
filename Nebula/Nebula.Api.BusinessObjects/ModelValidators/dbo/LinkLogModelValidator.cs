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
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LinkLogModel model)
		{
			this.DateEnteredRules();
			this.LinkIdRules();
			this.LogRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>485156b064934b74aece7ed44c75e0a2</Hash>
</Codenesium>*/