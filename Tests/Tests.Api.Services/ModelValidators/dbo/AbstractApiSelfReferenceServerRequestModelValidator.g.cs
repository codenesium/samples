using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
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
    <Hash>f9559a8d528eee9f85ce445b510a8cf8</Hash>
</Codenesium>*/