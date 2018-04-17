using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class StudioModelValidator: AbstractStudioModelValidator, IStudioModelValidator
	{
		public StudioModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(StudioModel model)
		{
			this.NameRules();
			this.WebsiteRules();
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateIdRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, StudioModel model)
		{
			this.NameRules();
			this.WebsiteRules();
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateIdRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>72eab37a8403eaffd613033e35627c37</Hash>
</Codenesium>*/