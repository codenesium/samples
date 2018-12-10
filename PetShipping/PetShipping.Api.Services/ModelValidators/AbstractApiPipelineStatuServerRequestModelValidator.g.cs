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
	public abstract class AbstractApiPipelineStatuServerRequestModelValidator : AbstractValidator<ApiPipelineStatuServerRequestModel>
	{
		private int existingRecordId;

		protected IPipelineStatuRepository PipelineStatuRepository { get; private set; }

		public AbstractApiPipelineStatuServerRequestModelValidator(IPipelineStatuRepository pipelineStatuRepository)
		{
			this.PipelineStatuRepository = pipelineStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatuServerRequestModel model, int id)
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
    <Hash>bb6088892ea2533b412bf0106ac3a051</Hash>
</Codenesium>*/