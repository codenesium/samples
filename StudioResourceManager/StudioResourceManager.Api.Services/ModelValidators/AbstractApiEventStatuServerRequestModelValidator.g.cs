using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventStatuServerRequestModelValidator : AbstractValidator<ApiEventStatuServerRequestModel>
	{
		private int existingRecordId;

		private IEventStatuRepository eventStatuRepository;

		public AbstractApiEventStatuServerRequestModelValidator(IEventStatuRepository eventStatuRepository)
		{
			this.eventStatuRepository = eventStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStatuServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>b1fab051cc4f225d234b913dd7a63887</Hash>
</Codenesium>*/