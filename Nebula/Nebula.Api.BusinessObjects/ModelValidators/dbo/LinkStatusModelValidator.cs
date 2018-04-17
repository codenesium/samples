using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class LinkStatusModelValidator: AbstractLinkStatusModelValidator, ILinkStatusModelValidator
	{
		public LinkStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LinkStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LinkStatusModel model)
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
    <Hash>d2a4dffb48f727b8c35a89e3015d8819</Hash>
</Codenesium>*/