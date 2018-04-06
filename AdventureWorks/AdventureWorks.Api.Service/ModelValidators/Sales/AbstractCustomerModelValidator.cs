using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractCustomerModelValidator: AbstractValidator<CustomerModel>
	{
		public new ValidationResult Validate(CustomerModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CustomerModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPersonRepository PersonRepository {get; set;}
		public IStoreRepository StoreRepository {get; set;}
		public ISalesTerritoryRepository SalesTerritoryRepository {get; set;}
		public virtual void PersonIDRules()
		{
			RuleFor(x => x.PersonID).Must(BeValidPerson).When(x => x ?.PersonID != null).WithMessage("Invalid reference");
		}

		public virtual void StoreIDRules()
		{
			RuleFor(x => x.StoreID).Must(BeValidStore).When(x => x ?.StoreID != null).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).Must(BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
		}

		public virtual void AccountNumberRules()
		{
			RuleFor(x => x.AccountNumber).NotNull();
			RuleFor(x => x.AccountNumber).Length(0,10);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidPerson(Nullable<int> id)
		{
			Response response = new Response();

			this.PersonRepository.GetById(id.GetValueOrDefault(),response);
			return response.People.Count > 0;
		}

		public bool BeValidStore(Nullable<int> id)
		{
			Response response = new Response();

			this.StoreRepository.GetById(id.GetValueOrDefault(),response);
			return response.Stores.Count > 0;
		}

		public bool BeValidSalesTerritory(Nullable<int> id)
		{
			Response response = new Response();

			this.SalesTerritoryRepository.GetById(id.GetValueOrDefault(),response);
			return response.SalesTerritories.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>263ad5888025f2bb3ba3a1fea65a4fb2</Hash>
</Codenesium>*/