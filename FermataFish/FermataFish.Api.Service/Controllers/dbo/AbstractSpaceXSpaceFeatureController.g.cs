using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractSpaceXSpaceFeatureController: AbstractApiController
	{
		protected IBOSpaceXSpaceFeature spaceXSpaceFeatureManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ServiceSettings settings,
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceXSpaceFeature spaceXSpaceFeatureManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.spaceXSpaceFeatureManager = spaceXSpaceFeatureManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(ApiResponse), 404)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] SpaceXSpaceFeatureModel model)
		{
			var result = await this.spaceXSpaceFeatureManager.Create(model);

			if(result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.settings.ExternalBaseUrl}/api/spaceXSpaceFeatures/{result.Id.ToString()}");
				return this.Ok(result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SpaceXSpaceFeatureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			foreach (var model in models)
			{
				var result = await this.spaceXSpaceFeatureManager.Create(model);

				if(!result.Success)
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.NoContent();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] SpaceXSpaceFeatureModel model)
		{
			var result = await this.spaceXSpaceFeatureManager.Update(id, model);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.spaceXSpaceFeatureManager.Delete(id);

			if(result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("BySpaceId/{id}")]
		[ReadOnly]
		[Route("~/api/Spaces/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySpaceFeatureId/{id}")]
		[ReadOnly]
		[Route("~/api/SpaceFeatures/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceFeatureId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceFeatureId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>6871f8779decd8f10b1d22c5c95b1825</Hash>
</Codenesium>*/