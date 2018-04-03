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
	public abstract class AbstractLocationsController: AbstractEntityFrameworkApiController
	{
		protected ILocationRepository _locationRepository;
		protected ILocationModelValidator _locationModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractLocationsController(
			ILogger<AbstractLocationsController> logger,
			ApplicationContext context,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator
			) : base(logger,context)
		{
			this._locationRepository = locationRepository;
			this._locationModelValidator = locationModelValidator;
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
			Response response = new Response();

			this._locationRepository.GetById(id,response);
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
			Response response = new Response();

			this._locationRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
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
			this._locationModelValidator.CreateMode();
			var validationResult = this._locationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._locationRepository.Create(model.Name,
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
		[Route("CreateMany")]
		[ModelValidateFilter]
		[LocationFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<LocationModel> models)
		{
			this._locationModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._locationModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._locationRepository.Create(model.Name,
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
		public virtual IActionResult Update(short locationID,LocationModel model)
		{
			this._locationModelValidator.UpdateMode();
			var validationResult = this._locationModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._locationRepository.Update(locationID,  model.Name,
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
			this._locationRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>6166ba2edf27b51e1d2494e242872276</Hash>
</Codenesium>*/