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
	public abstract class AbstractApiPersonRefServerRequestModelValidator : AbstractValidator<ApiPersonRefServerRequestModel>
	{
		private int existingRecordId;

		private IPersonRefRepository personRefRepository;

		public AbstractApiPersonRefServerRequestModelValidator(IPersonRefRepository personRefRepository)
		{
			this.personRefRepository = personRefRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonRefServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonAIdRules()
		{
		}

		public virtual void PersonBIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc0f563f1992676f02f007428041e177</Hash>
</Codenesium>*/