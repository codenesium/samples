using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPersonServerRequestModelValidator : AbstractApiPersonServerRequestModelValidator, IApiPersonServerRequestModelValidator
	{
		public ApiPersonServerRequestModelValidator(IPersonRepository personRepository)
			: base(personRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model)
		{
			this.AdditionalContactInfoRules();
			this.DemographicRules();
			this.EmailPromotionRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.MiddleNameRules();
			this.ModifiedDateRules();
			this.NameStyleRules();
			this.PersonTypeRules();
			this.RowguidRules();
			this.SuffixRules();
			this.TitleRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model)
		{
			this.AdditionalContactInfoRules();
			this.DemographicRules();
			this.EmailPromotionRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.MiddleNameRules();
			this.ModifiedDateRules();
			this.NameStyleRules();
			this.PersonTypeRules();
			this.RowguidRules();
			this.SuffixRules();
			this.TitleRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f426f3538a8fd3e5107cdaf707e1edee</Hash>
</Codenesium>*/