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
	public abstract class AbstractApiCompositePrimaryKeyServerRequestModelValidator : AbstractValidator<ApiCompositePrimaryKeyServerRequestModel>
	{
		private int existingRecordId;

		private ICompositePrimaryKeyRepository compositePrimaryKeyRepository;

		public AbstractApiCompositePrimaryKeyServerRequestModelValidator(ICompositePrimaryKeyRepository compositePrimaryKeyRepository)
		{
			this.compositePrimaryKeyRepository = compositePrimaryKeyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCompositePrimaryKeyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Id2Rules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>55d4141dcc85a5cf554231d1d8712876</Hash>
</Codenesium>*/