using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractStoreModelValidator: AbstractValidator<StoreModel>
	{
		public new ValidationResult Validate(StoreModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StoreModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBusinessEntityRepository BusinessEntityRepository {get; set;}
		public ISalesPersonRepository SalesPersonRepository {get; set;}
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void SalesPersonIDRules()
		{
			RuleFor(x => x.SalesPersonID).Must(BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		public virtual void DemographicsRules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidBusinessEntity(int id)
		{
			Response response = new Response();

			this.BusinessEntityRepository.GetById(id,response);
			return response.BusinessEntities.Count > 0;
		}

		public bool BeValidSalesPerson(Nullable<int> id)
		{
			Response response = new Response();

			this.SalesPersonRepository.GetById(id.GetValueOrDefault(),response);
			return response.SalesPersons.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>5d756506eaf5645152b2e1b284e9c82c</Hash>
</Codenesium>*/