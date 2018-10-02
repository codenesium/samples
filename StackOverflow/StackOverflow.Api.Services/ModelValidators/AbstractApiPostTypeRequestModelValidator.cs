using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostTypeRequestModelValidator : AbstractValidator<ApiPostTypeRequestModel>
	{
		private int existingRecordId;

		private IPostTypeRepository postTypeRepository;

		public AbstractApiPostTypeRequestModelValidator(IPostTypeRepository postTypeRepository)
		{
			this.postTypeRepository = postTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypeRequestModel model, int id)
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
    <Hash>0025c39cfd5ccba1a55f4c80be72ef43</Hash>
</Codenesium>*/