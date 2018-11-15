using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostTypeServerRequestModelValidator : AbstractValidator<ApiPostTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPostTypeRepository postTypeRepository;

		public AbstractApiPostTypeServerRequestModelValidator(IPostTypeRepository postTypeRepository)
		{
			this.postTypeRepository = postTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypeServerRequestModel model, int id)
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
    <Hash>b0063b3fe4de98f3cb3863f49582a1fe</Hash>
</Codenesium>*/