using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiSelfReferenceServerRequestModelValidator : AbstractValidator<ApiSelfReferenceServerRequestModel>
	{
		private int existingRecordId;

		private ISelfReferenceRepository selfReferenceRepository;

		public AbstractApiSelfReferenceServerRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
		{
			this.selfReferenceRepository = selfReferenceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSelfReferenceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SelfReferenceIdRules()
		{
		}

		public virtual void SelfReferenceId2Rules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e1aa1336987a14fad5a23e261914a9cd</Hash>
</Codenesium>*/