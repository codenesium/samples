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
		public virtual IActionResult Update(int SalesOrderID,SalesOrderHeaderSalesReasonModel model)
		{
			this._salesOrderHeaderSalesReasonModelValidator.UpdateMode();
			var validationResult = this._salesOrderHeaderSalesReasonModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._salesOrderHeaderSalesReasonRepository.Update(SalesOrderID,  model.SalesReasonID,
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

		[HttpGet]
		[Route("BySalesOrderID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesOrderHeaders/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesOrderID(int id)
		{
			var response = new Response();

			this._salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesOrderID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("BySalesReasonID/{id}")]
		[SalesOrderHeaderSalesReasonFilter]
		[ReadOnlyFilter]
		[Route("~/api/SalesReasons/{id}/SalesOrderHeaderSalesReasons")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult BySalesReasonID(int id)
		{
			var response = new Response();

			this._salesOrderHeaderSalesReasonRepository.GetWhere(x => x.SalesReasonID == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>1fb276a3dc5220d64b0ad292c569a17f</Hash>
</Codenesium>*/