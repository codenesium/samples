using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStatusServerRequestModelValidator : AbstractValidator<ApiPipelineStatusServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineStatusRepository PipelineStatusRepository { get; private set; }

		public AbstractApiPipelineStatusServerRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
		{
			this.PipelineStatusRepository = pipelineStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>eedd38578543f5e8ea814b668eb38894</Hash>
</Codenesium>*/