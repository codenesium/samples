using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiFeedRequestModelValidator : AbstractValidator<ApiFeedRequestModel>
	{
		private string existingRecordId;

		private IFeedRepository feedRepository;

		public AbstractApiFeedRequestModelValidator(IFeedRepository feedRepository)
		{
			this.feedRepository = feedRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFeedRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FeedTypeRules()
		{
			this.RuleFor(x => x.FeedType).Length(0, 50);
		}

		public virtual void FeedUriRules()
		{
			this.RuleFor(x => x.FeedUri).Length(0, 512);
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiFeedRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		private async Task<bool> BeUniqueByName(ApiFeedRequestModel model,  CancellationToken cancellationToken)
		{
			Feed record = await this.feedRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>de0d4b14dc8c5866504ffb8d99a49a50</Hash>
</Codenesium>*/