using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPurchaseOrderHeaderModelValidator: AbstractValidator<PurchaseOrderHeaderModel>
	{
		public new ValidationResult Validate(PurchaseOrderHeaderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PurchaseOrderHeaderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository {get; set;}
		public IVendorRepository VendorRepository {get; set;}
		public IShipMethodRepository ShipMethodRepository {get; set;}
		public virtual void RevisionNumberRules()
		{
			RuleFor(x => x.RevisionNumber).NotNull();
		}

		public virtual void StatusRules()
		{
			RuleFor(x => x.Status).NotNull();
		}

		public virtual void EmployeeIDRules()
		{
			RuleFor(x => x.EmployeeID).NotNull();
			RuleFor(x => x.EmployeeID).Must(BeValidEmployee).When(x => x ?.EmployeeID != null).WithMessage("Invalid reference");
		}

		public virtual void VendorIDRules()
		{
			RuleFor(x => x.VendorID).NotNull();
			RuleFor(x => x.VendorID).Must(BeValidVendor).When(x => x ?.VendorID != null).WithMessage("Invalid reference");
		}

		public virtual void ShipMethodIDRules()
		{
			RuleFor(x => x.ShipMethodID).NotNull();
			RuleFor(x => x.ShipMethodID).Must(BeValidShipMethod).When(x => x ?.ShipMethodID != null).WithMessage("Invalid reference");
		}

		public virtual void OrderDateRules()
		{
			RuleFor(x => x.OrderDate).NotNull();
		}

		public virtual void ShipDateRules()
		{                       }

		public virtual void SubTotalRules()
		{
			RuleFor(x => x.SubTotal).NotNull();
		}

		public virtual void TaxAmtRules()
		{
			RuleFor(x => x.TaxAmt).NotNull();
		}

		public virtual void FreightRules()
		{
			RuleFor(x => x.Freight).NotNull();
		}

		public virtual void TotalDueRules()
		{
			RuleFor(x => x.TotalDue).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidEmployee(int id)
		{
			Response response = new Response();

			this.EmployeeRepository.GetById(id,response);
			return response.Employees.Count > 0;
		}

		public bool BeValidVendor(int id)
		{
			Response response = new Response();

			this.VendorRepository.GetById(id,response);
			return response.Vendors.Count > 0;
		}

		public bool BeValidShipMethod(int id)
		{
			Response response = new Response();

			this.ShipMethodRepository.GetById(id,response);
			return response.ShipMethods.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>35c6d215629b3ed647dedbfa8e3d20b2</Hash>
</Codenesium>*/