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
	public abstract class AbstractSalesOrderHeaderSalesReasonsController: AbstractEntityFrameworkApiController
	{
		protected ISalesOrderHeaderSalesReasonRepository _salesOrderHeaderSalesReasonRepository;
		protected ISalesOrderHeaderSalesReasonModelValidator _salesOrderHeaderSalesReasonModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractSalesOrderHeaderSalesReasonsController(
			ILogger<AbstractSalesOrderHeaderSalesReasonsController> logger,
			ApplicationContext context,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			) : base(logger,context)
		{
			this._salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this._salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
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
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._salesOrderHeaderSalesReasonRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._salesOrderHeaderSalesReasonRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(SalesOrderHeaderSalesReasonModel model)
		{
			this._salesOrderHeaderSalesReasonModelValidator.CreateMode();
			var validationResult = this._salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._salesOrderHeaderSalesReasonRepository.Create(model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<SalesOrderHeaderSalesReasonModel> models)
		{
			this._salesOrderHeaderSalesReasonModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._salesOrderHeaderSalesReasonModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._salesOrderHeaderSalesReasonRepository.Create(model.SalesReasonID,
				                                                   model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int salesOrderID,SalesOrderHeaderSalesReasonModel model)
		{
			this._salesOrderHeaderSalesReasonModelValidator.UpdateMode();
			var validationResult = this._salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesOrderHeaderSalesReasonRepository.Update(salesOrderID,  model.SalesReasonID,
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
		[SalesOrderHeaderSalesReasonFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._salesOrderHeaderSalesReasonRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>9cab132c2e22ab9b24ac6944ce9d5937</Hash>
</Codenesium>*/