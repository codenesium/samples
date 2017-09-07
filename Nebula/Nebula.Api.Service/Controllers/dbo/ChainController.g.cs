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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	public class ChainsControllerAbstract: AbstractEntityFrameworkApiController
	{
		protected ChainRepository _chainRepository;
		protected ChainModelValidator _chainModelValidator;
		protected int SearchRecordLimit {get; set;} = 1000;
		protected int SearchRecordDefault {get; set;} = 250;
		public ChainsControllerAbstract(
			ILogger logger,
			DbContext context,
			ChainRepository chainRepository,
			ChainModelValidator chainModelValidator
			) : base(logger,context)
		{
			this._chainRepository = chainRepository;
			this._chainModelValidator = chainModelValidator;
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
		[ChainFilter]
		[ReadOnlyFilter]
		public virtual IHttpActionResult Get(int id)
		{
			Response response = new Response();

			this._chainRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ChainFilter]
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

			this._chainRepository.GetWhereDynamic(whereClause,response,offset,limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Create(ChainModel model)
		{
			this._chainModelValidator.CreateMode();
			var validationResult = this._chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._chainRepository.Create(model.ChainStatusId,
				                                      model.ExternalId,
				                                      model.Id,
				                                      model.Name,
				                                      model.TeamId);
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
		[ChainFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult CreateMany(List<ChainModel> models)
		{
			this._chainModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._chainModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._chainRepository.Create(model.ChainStatusId,
				                             model.ExternalId,
				                             model.Id,
				                             model.Name,
				                             model.TeamId);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ChainFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Update(int id,ChainModel model)
		{
			this._chainModelValidator.UpdateMode();
			var validationResult = this._chainModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._chainRepository.Update(model.ChainStatusId,
				                             model.ExternalId,
				                             model.Id,
				                             model.Name,
				                             model.TeamId);
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
		[ChainFilter]
		[UnitOfWorkActionFilter]
		public IHttpActionResult Patch(int id, JsonPatchDocument<ChainModel> patch)
		{
			Response response = new Response();

			this._chainRepository.GetById(id, response);
			if (response.Chains.Count > 0)
			{
				var model = new ChainModel(response.Chains.First());

				patch.ApplyUpdatesTo(model);
				this._chainModelValidator.PatchMode();
				var validationResult = this._chainModelValidator.Validate(model);
				if (validationResult.IsValid)
				{
					this._chainRepository.Update(model.ChainStatusId,
					                             model.ExternalId,
					                             model.Id,
					                             model.Name,
					                             model.TeamId);
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
		[ChainFilter]
		[UnitOfWorkActionFilter]
		public virtual IHttpActionResult Delete(int id)
		{
			this._chainRepository.Delete(id);
			return Ok();
		}

		[HttpGet]
		[Route("ByChainStatusId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/ChainStatus/{id}/Chains")]
		public virtual IHttpActionResult ByChainStatusId(int id)
		{
			var response = new Response();

			this._chainRepository.GetWhere(x => x.chainStatusId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("ByTeamId/{id}")]
		[ChainFilter]
		[ReadOnlyFilter]
		[Route("~/api/Teams/{id}/Chains")]
		public virtual IHttpActionResult ByTeamId(int id)
		{
			var response = new Response();

			this._chainRepository.GetWhere(x => x.teamId == id, response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>f161038182a3b5b48c6bb13191f91c19</Hash>
</Codenesium>*/