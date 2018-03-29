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
	public abstract class AbstractBillOfMaterialsController: AbstractEntityFrameworkApiController
	{
		protected IBillOfMaterialsRepository _billOfMaterialsRepository;
		protected IBillOfMaterialsModelValidator _billOfMaterialsModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractBillOfMaterialsController(
			ILogger<AbstractBillOfMaterialsController> logger,
			ApplicationContext context,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IBillOfMaterialsModelValidator billOfMaterialsModelValidator
			) : base(logger,context)
		{
			this._billOfMaterialsRepository = billOfMaterialsRepository;
			this._billOfMaterialsModelValidator = billOfMaterialsModelValidator;
		}

		protected void AddErrors(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._billOfMaterialsRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._billOfMaterialsRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
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
			this._billOfMaterialsModelValidator.CreateMode();
			var validationResult = this._billOfMaterialsModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._billOfMaterialsRepository.Create(model.ProductAssemblyID,
				                                                model.ComponentID,
				                                                model.StartDate,
				                                                model.EndDate,
				                                                model.UnitMeasureCode,
				                                                model.BOMLevel,
				                                                model.PerAssemblyQty,
				                                                model.ModifiedDate);
				return Ok(id);
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPost]
		[Route("CreateMany")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<BillOfMaterialsModel> models)
		{
			this._billOfMaterialsModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._billOfMaterialsModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._billOfMaterialsRepository.Create(model.ProductAssemblyID,
				                                       model.ComponentID,
				                                       model.StartDate,
				                                       model.EndDate,
				                                       model.UnitMeasureCode,
				                                       model.BOMLevel,
				                                       model.PerAssemblyQty,
				                                       model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[BillOfMaterialsFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int BillOfMaterialsID,BillOfMaterialsModel model)
		{
			this._billOfMaterialsModelValidator.UpdateMode();
			var validationResult = this._billOfMaterialsModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._billOfMaterialsRepository.Update(BillOfMaterialsID,  model.ProductAssemblyID,
				                                       model.ComponentID,
				                                       model.StartDate,
				                                       model.EndDate,
				                                       model.UnitMeasureCode,
				                                       model.BOMLevel,
				                                       model.PerAssemblyQty,
				                                       model.ModifiedDate);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
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
			this._billOfMaterialsRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByProductAssemblyID/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByProductAssemblyID(int id)
		{
			var response = new Response();

			this._billOfMaterialsRepository.GetWhere(x => x.ProductAssemblyID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByComponentID/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/Products/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByComponentID(int id)
		{
			var response = new Response();

			this._billOfMaterialsRepository.GetWhere(x => x.ComponentID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByUnitMeasureCode/{id}")]
		[BillOfMaterialsFilter]
		[ReadOnlyFilter]
		[Route("~/api/UnitMeasures/{id}/BillOfMaterials")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByUnitMeasureCode(string id)
		{
			var response = new Response();

			this._billOfMaterialsRepository.GetWhere(x => x.UnitMeasureCode == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>bdfe743c29953362d48a2395643089c7</Hash>
</Codenesium>*/