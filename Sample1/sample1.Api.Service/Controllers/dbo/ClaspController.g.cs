using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using JsonPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;
namespace sample1NS.Api.Service
{
	public class ClaspControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected ClaspRepository _claspRepository;
		protected ClaspModelValidator _claspModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public ClaspControllerAbstract(
			ILogger logger,
			DbContext context,
			ClaspRepository claspRepository,
			ClaspModelValidator claspModelValidator
			) : base(logger,context)
		{
			this._claspRepository = claspRepository;
			this._claspModelValidator = claspModelValidator;
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
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._claspRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ClaspFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Search()
		{
			var queryParameters = ControllerContext.Request.GetQueryNameValuePairs();
			string whereClause = String.Empty;

			int offset = 0;
			int limit = this.SearchRecordDefault;

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Equals(default (KeyValuePair<string, string>)))
			{
				offset = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "OFFSET").Value.ToInt();
			}

			if (!queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Equals(default (KeyValuePair<string, string>)))
			{
				limit = queryParameters.FirstOrDefault(x => x.Key.ToUpper() == "LIMIT").Value.ToInt();
			}

			if(limit > this.SearchRecordLimit)
			{
				return BadRequest($"Limit of {limit} exceeds maximum request size of {this.SearchRecordLimit} records");
			}

			foreach(var parameter in queryParameters)
			{
				if(parameter.Key.ToUpper() == "OFFSET" || parameter.Key.ToUpper() == "LIMIT")
				{
					continue;
				}

				if(!String.IsNullOrEmpty(whereClause))
				{
					whereClause += " && ";
				}

				if (parameter.Value.ToNullableInt() != null)
				{
					whereClause += $"{parameter.Key}.Equals({parameter.Value})";
				}
				else if (parameter.Value.ToNullableGuid() != null)
				{
					whereClause += $"{parameter.Key}.Equals(Guid(\"{parameter.Value}\"))";
				}
				else
				{
					whereClause += $"{parameter.Key}.Equals(\"{parameter.Value}\")";
				}
			}
			if(String.IsNullOrWhiteSpace(whereClause))
			{
				whereClause = "1=1";
			}
			Response response = new Response();

			this._claspRepository.GetWhereDynamic(whereClause,response,offset,limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(ClaspModel model)
		{
			this._claspModelValidator.CreateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._claspRepository.Create(model.Id,
				                                      model.NextChainId,
				                                      model.PreviousChainId);
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
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<ClaspModel> models)
		{
			this._claspModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._claspModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._claspRepository.Create(model.Id,
				                             model.NextChainId,
				                             model.PreviousChainId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,ClaspModel model)
		{
			this._claspModelValidator.UpdateMode();
			var validationResult = this._claspModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._claspRepository.Update(model.Id,
				                             model.NextChainId,
				                             model.PreviousChainId);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<ClaspModel> patch)
		{
			Response response = new Response();

			this._claspRepository.GetById(id, response);
			if (response.Clasps.Count > 0)
			{
				var model = new ClaspModel(response.Clasps.First());

				patch.ApplyUpdatesTo(model);
				this._claspModelValidator.PatchMode();
				var validationResult = this._claspModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._claspRepository.Update(model.Id,
					                             model.NextChainId,
					                             model.PreviousChainId);
					return Ok();
				}
				else
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}
			else
			{
				return BadRequest("Entity not found");
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ClaspFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._claspRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByNextChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		public virtual IHttpActionResult ByNextChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.nextChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByPreviousChainId/{id}")]
		[ClaspFilter]
		[ReadOnlyFilter]
		[Route("~/api/Chains/{id}/Clasps")]
		public virtual IHttpActionResult ByPreviousChainId(int id)
		{
			var response = new Response();

			this._claspRepository.GetWhere(x => x.previousChainId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>edae7090fc3049ccc930600d149c0e13</Hash>
</Codenesium>*/