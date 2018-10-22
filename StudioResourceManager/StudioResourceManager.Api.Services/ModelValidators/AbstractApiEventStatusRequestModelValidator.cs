using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventStatusRequestModelValidator : AbstractValidator<ApiEventStatusRequestModel>
	{
		private int existingRecordId;

		private IEventStatusRepository eventStatusRepository;

		public AbstractApiEventStatusRequestModelValidator(IEventStatusRepository eventStatusRepository)
		{
			this.eventStatusRepository = eventStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStatusRequestModel model, int id)
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
    <Hash>2b2a88498829289523295c9234e48952</Hash>
</Codenesium>*/