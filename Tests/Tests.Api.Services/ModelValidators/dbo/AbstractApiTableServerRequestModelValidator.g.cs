using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTableServerRequestModelValidator : AbstractValidator<ApiTableServerRequestModel>
	{
		private int existingRecordId;

		private ITableRepository tableRepository;

		public AbstractApiTableServerRequestModelValidator(ITableRepository tableRepository)
		{
			this.tableRepository = tableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>e4b60246da97ac0b352e2b1fcbf54c8b</Hash>
</Codenesium>*/