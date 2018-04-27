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
		[ProducesResponseType(typeof(POCOSpaceXSpaceFeature), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOSpaceXSpaceFeature response = this.spaceXSpaceFeatureManager.GetById(id).SpaceXSpaceFeatures.FirstOrDefault();
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSpaceXSpaceFeature>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SpaceXSpaceFeatures);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOSpaceXSpaceFeature), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] SpaceXSpaceFeatureModel model)
		{
			CreateResponse<int> result = await this.spaceXSpaceFeatureManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/SpaceXSpaceFeatures/{result.Id.ToString()}");
				POCOSpaceXSpaceFeature response = this.spaceXSpaceFeatureManager.GetById(result.Id).SpaceXSpaceFeatures.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<int>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<SpaceXSpaceFeatureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.spaceXSpaceFeatureManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOSpaceXSpaceFeature), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] SpaceXSpaceFeatureModel model)
		{
			try
			{
				ActionResponse result = await this.spaceXSpaceFeatureManager.Update(id, model);

				if (result.Success)
				{
					POCOSpaceXSpaceFeature response = this.spaceXSpaceFeatureManager.GetById(id).SpaceXSpaceFeatures.First();
					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.spaceXSpaceFeatureManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("BySpaceFeatureId/{id}")]
		[ReadOnly]
		[Route("~/api/SpaceFeatures/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSpaceXSpaceFeature>), 200)]
		public virtual IActionResult BySpaceFeatureId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceFeatureId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SpaceXSpaceFeatures);
			}
		}

		[HttpGet]
		[Route("BySpaceId/{id}")]
		[ReadOnly]
		[Route("~/api/Spaces/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOSpaceXSpaceFeature>), 200)]
		public virtual IActionResult BySpaceId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureManager.GetWhere(x => x.SpaceId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.SpaceXSpaceFeatures);
			}
		}
	}
}

/*<Codenesium>
    <Hash>f4572f7ed5008a2a6859504e2e9fcb97</Hash>
</Codenesium>*/