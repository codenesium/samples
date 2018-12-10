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

		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		public AbstractApiSelfReferenceServerRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
		{
			this.SelfReferenceRepository = selfReferenceRepository;
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
    <Hash>d4e3ff37da787d17095a78c2e8ad8698</Hash>
</Codenesium>*/