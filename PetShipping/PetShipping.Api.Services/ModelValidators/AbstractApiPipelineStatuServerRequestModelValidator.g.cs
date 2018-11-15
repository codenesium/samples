using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStatuServerRequestModelValidator : AbstractValidator<ApiPipelineStatuServerRequestModel>
	{
		private int existingRecordId;

		private IPipelineStatuRepository pipelineStatuRepository;

		public AbstractApiPipelineStatuServerRequestModelValidator(IPipelineStatuRepository pipelineStatuRepository)
		{
			this.pipelineStatuRepository = pipelineStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineStatuServerRequestModel model, int id)
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
    <Hash>e09f299ad9617f4b6c4c46fd6128cefc</Hash>
</Codenesium>*/