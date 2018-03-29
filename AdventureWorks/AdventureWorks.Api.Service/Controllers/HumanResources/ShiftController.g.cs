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
	public abstract class AbstractShiftsController: AbstractEntityFrameworkApiController
	{
		protected IShiftRepository _shiftRepository;
		protected IShiftModelValidator _shiftModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractShiftsController(
			ILogger<AbstractShiftsController> logger,
			ApplicationContext context,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator
			) : base(logger,context)
		{
			this._shiftRepository = shiftRepository;
			this._shiftModelValidator = shiftModelValidator;
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

			this._shiftRepository.GetById(id,response);
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

			this._shiftRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._shiftModelValidator.CreateMode();
			var validationResult = this._shiftModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._shiftRepository.Create(model.Name,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[ShiftFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ShiftModel> models)
		{
			this._shiftModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._shiftModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._shiftRepository.Create(model.Name,
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
			this._shiftModelValidator.UpdateMode();
			var validationResult = this._shiftModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._shiftRepository.Update(ShiftID,  model.Name,
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
			this._shiftRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>b5b8cd4c359ded2a76957aa6b9fceae9</Hash>
</Codenesium>*/