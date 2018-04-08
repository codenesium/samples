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
	public abstract class AbstractShiftsController: AbstractApiController
	{
		protected IShiftRepository shiftRepository;
		protected IShiftModelValidator shiftModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShiftsController(
			ILogger<AbstractShiftsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
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
		[ShiftFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.shiftRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ShiftFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.shiftRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ShiftFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ShiftModel model)
		{
			this.shiftModelValidator.CreateMode();
			var validationResult = this.shiftModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.shiftRepository.Create(model.Name,
				                                     model.StartTime,
				                                     model.EndTime,
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
		[Route("BulkInsert")]
		[ModelValidateFilter]
		[ShiftFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ShiftModel> models)
		{
			this.shiftModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.shiftModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.shiftRepository.Create(model.Name,
				                            model.StartTime,
				                            model.EndTime,
				                            model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ShiftFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ShiftID,ShiftModel model)
		{
			this.shiftModelValidator.UpdateMode();
			var validationResult = this.shiftModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.shiftRepository.Update(ShiftID,  model.Name,
				                            model.StartTime,
				                            model.EndTime,
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
		[ShiftFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.shiftRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>25bda53a2c257b1f81fef0e6b502922e</Hash>
</Codenesium>*/