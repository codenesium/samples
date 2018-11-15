using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiSchemaBPersonServerRequestModelValidator : AbstractValidator<ApiSchemaBPersonServerRequestModel>
	{
		private int existingRecordId;

		private ISchemaBPersonRepository schemaBPersonRepository;

		public AbstractApiSchemaBPersonServerRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
		{
			this.schemaBPersonRepository = schemaBPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSchemaBPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>d02411d330e839be207147e8c95ec1be</Hash>
</Codenesium>*/