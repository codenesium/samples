using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractApiStudioRequestModelValidator : AbstractValidator<ApiStudioRequestModel>
	{
		private int existingRecordId;

		private IStudioRepository studioRepository;

		public AbstractApiStudioRequestModelValidator(IStudioRepository studioRepository)
		{
			this.studioRepository = studioRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudioRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull();
			this.RuleFor(x => x.Address1).Length(0, 128);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull();
			this.RuleFor(x => x.Address2).Length(0, 128);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull();
			this.RuleFor(x => x.City).Length(0, 128);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void ProvinceRules()
		{
			this.RuleFor(x => x.Province).NotNull();
			this.RuleFor(x => x.Province).Length(0, 90);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull();
			this.RuleFor(x => x.Website).Length(0, 128);
		}

		public virtual void ZipRules()
		{
			this.RuleFor(x => x.Zip).NotNull();
			this.RuleFor(x => x.Zip).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>d48472abe8512e7672b5f38ce4f8a584</Hash>
</Codenesium>*/