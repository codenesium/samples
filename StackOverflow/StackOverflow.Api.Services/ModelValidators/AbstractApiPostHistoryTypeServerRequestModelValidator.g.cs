using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostHistoryTypeServerRequestModelValidator : AbstractValidator<ApiPostHistoryTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPostHistoryTypeRepository postHistoryTypeRepository;

		public AbstractApiPostHistoryTypeServerRequestModelValidator(IPostHistoryTypeRepository postHistoryTypeRepository)
		{
			this.postHistoryTypeRepository = postHistoryTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull();
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>d03b6acfa909fd204432c5591ab50c61</Hash>
</Codenesium>*/