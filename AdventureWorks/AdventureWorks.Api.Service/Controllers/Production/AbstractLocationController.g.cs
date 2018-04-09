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
	public abstract class AbstractLocationsController: AbstractApiController
	{
		protected ILocationRepository locationRepository;
		protected ILocationModelValidator locationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLocationsController(
			ILogger<AbstractLocationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
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
		[LocationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(short id)
		{
			Response response = this.locationRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[LocationFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = this.locationRepository.GetWhereDynamic(query.WhereClause,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[LocationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(LocationModel model)
		{
			this.locationModelValidator.CreateMode();
			var validationResult = this.locationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.locationRepository.Create(model.Name,
				                                        model.CostRate,
				                                        model.Availability,
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
		[LocationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<LocationModel> models)
		{
			this.locationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.locationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.locationRepository.Create(model.Name,
				                               model.CostRate,
				                               model.Availability,
				                               model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[LocationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(short id,LocationModel model)
		{
			if(this.locationRepository.GetByIdDirect(id) == null)
			{
				return BadRequest(this.ModelState);
			}

			this.locationModelValidator.UpdateMode();
			var validationResult = this.locationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.locationRepository.Update(id,  model.Name,
				                               model.CostRate,
				                               model.Availability,
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
		[LocationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(short id)
		{
			this.locationRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>1bb18cec4bd4c2fffdcf8927183687f2</Hash>
</Codenesium>*/