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
	public abstract class AbstractApiCompositePrimaryKeyRequestModelValidator : AbstractValidator<ApiCompositePrimaryKeyRequestModel>
	{
		private int existingRecordId;

		private ICompositePrimaryKeyRepository compositePrimaryKeyRepository;

		public AbstractApiCompositePrimaryKeyRequestModelValidator(ICompositePrimaryKeyRepository compositePrimaryKeyRepository)
		{
			this.compositePrimaryKeyRepository = compositePrimaryKeyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCompositePrimaryKeyRequestModel model, int id)
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
    <Hash>4eda5ef860dfe79f4ffa19eb3c97cd8d</Hash>
</Codenesium>*/