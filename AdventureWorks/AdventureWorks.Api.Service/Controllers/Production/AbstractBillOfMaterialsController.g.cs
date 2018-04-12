using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractBillOfMaterialsController: AbstractApiController
	{
		protected IBillOfMaterialsRepository billOfMaterialsRepository;

		protected IBillOfMaterialsModelValidator billOfMaterialsModelValidator;

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBillOfMaterialsController(
			ILogger<AbstractBillOfMaterialsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IBillOfMaterialsModelValidator billOfMaterialsModelValidator
			)
			: base(logger, transactionCoordinator)
		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = this.billOfMaterialsRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.billOfMaterialsRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(BillOfMaterialsModel model)
		{
			this.billOfMaterialsModelValidator.CreateMode();
			var validationResult = this.billOfMaterialsModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.billOfMaterialsRepository.Create(
					model.ProductAssemblyID,
					model.ComponentID,
					model.StartDate,
					model.EndDate,
					model.UnitMeasureCode,
					model.BOMLevel,
					model.PerAssemblyQty,
					model.ModifiedDate);
				return this.Ok(id);
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<BillOfMaterialsModel> models)
		{
			this.billOfMaterialsModelValidator.CreateMode();
			foreach (var model in models)
			{
				var validationResult = this.billOfMaterialsModelValidator.Validate(model);
				if (!validationResult.IsValid)
				{
					this.AddErrors(validationResult);
					return this.BadRequest(this.ModelState);
				}
			}

			foreach (var model in models)
			{
				this.billOfMaterialsRepository.Create(
					model.ProductAssemblyID,
					model.ComponentID,
					model.StartDate,
					model.EndDate,
					model.UnitMeasureCode,
					model.BOMLevel,
					model.PerAssemblyQty,
					model.ModifiedDate);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, BillOfMaterialsModel model)
		{
			if (this.billOfMaterialsRepository.GetByIdDirect(id) == null)
			{
				return this.BadRequest(this.ModelState);
			}

			this.billOfMaterialsModelValidator.UpdateMode();
			var validationResult = this.billOfMaterialsModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.billOfMaterialsRepository.Update(
					id,
					model.ProductAssemblyID,
					model.ComponentID,
					model.StartDate,
					model.EndDate,
					model.UnitMeasureCode,
					model.BOMLevel,
					model.PerAssemblyQty,
					model.ModifiedDate);
				return this.Ok();
			}
			else
			{
				this.AddErrors(validationResult);
				return this.BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.billOfMaterialsRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByProductAssemblyID/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductAssemblyID(int id)
		{
			Response response = this.billOfMaterialsRepository.GetWhere(x => x.ProductAssemblyID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByComponentID/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByComponentID(int id)
		{
			Response response = this.billOfMaterialsRepository.GetWhere(x => x.ComponentID == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			Response response = this.billOfMaterialsRepository.GetWhere(x => x.UnitMeasureCode == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>0f576685fc8f9f4312cd0b6bea62346c</Hash>
</Codenesium>*/