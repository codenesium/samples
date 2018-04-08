using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public abstract class AbstractClaspsController: AbstractApiController
	{
		protected IClaspRepository claspRepository;
		protected IClaspModelValidator claspModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractClaspsController(
			ILogger<AbstractClaspsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator
			) : base(logger,transactionCoordinator)
		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
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
		[ClaspFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this.claspRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this.claspRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ClaspModel model)
		{
			this.claspModelValidator.CreateMode();
			var validationResult = this.claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this.claspRepository.Create(model.PreviousChainId,
				                                     model.NextChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert(List<ClaspModel> models)
		{
			this.claspModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this.claspModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this.claspRepository.Create(model.PreviousChainId,
				                            model.NextChainId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int Id,ClaspModel model)
		{
			this.claspModelValidator.UpdateMode();
			var validationResult = this.claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this.claspRepository.Update(Id,  model.PreviousChainId,
				                            model.NextChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.claspRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByPreviousChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByPreviousChainId(int id)
		{
			var response = new Response();

			this.claspRepository.GetWhere(x => x.PreviousChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByNextChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult ByNextChainId(int id)
		{
			var response = new Response();

			this.claspRepository.GetWhere(x => x.NextChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>18210a40c4162679f50a3dbc1ee16311</Hash>
</Codenesium>*/