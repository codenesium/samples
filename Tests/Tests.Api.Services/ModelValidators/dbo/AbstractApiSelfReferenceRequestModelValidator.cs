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
	public abstract class AbstractApiSelfReferenceRequestModelValidator : AbstractValidator<ApiSelfReferenceRequestModel>
	{
		private int existingRecordId;

		private ISelfReferenceRepository selfReferenceRepository;

		public AbstractApiSelfReferenceRequestModelValidator(ISelfReferenceRepository selfReferenceRepository)
		{
			this.selfReferenceRepository = selfReferenceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSelfReferenceRequestModel model, int id)
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
    <Hash>58a8dac132089ae24dbaef4dbf860e6e</Hash>
</Codenesium>*/