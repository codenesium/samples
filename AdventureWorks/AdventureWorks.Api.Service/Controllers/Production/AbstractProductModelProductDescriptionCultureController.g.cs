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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractProductModelProductDescriptionCultureController: AbstractApiController
	{
		protected IBOProductModelProductDescriptionCulture productModelProductDescriptionCultureManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelProductDescriptionCultureController(
			ServiceSettings settings,
			ILogger<AbstractProductModelProductDescriptionCultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelProductDescriptionCulture productModelProductDescriptionCultureManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.productModelProductDescriptionCultureManager = productModelProductDescriptionCultureManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOProductModelProductDescriptionCulture), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOProductModelProductDescriptionCulture response = this.productModelProductDescriptionCultureManager.GetById(id).ProductModelProductDescriptionCultures.FirstOrDefault();
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
		[ProducesResponseType(typeof(List<POCOProductModelProductDescriptionCulture>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.productModelProductDescriptionCultureManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.ProductModelProductDescriptionCultures);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOProductModelProductDescriptionCulture), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ProductModelProductDescriptionCultureModel model)
		{
			CreateResponse<int> result = await this.productModelProductDescriptionCultureManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ProductModelProductDescriptionCultures/{result.Id.ToString()}");
				POCOProductModelProductDescriptionCulture response = this.productModelProductDescriptionCultureManager.GetById(result.Id).ProductModelProductDescriptionCultures.First();
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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ProductModelProductDescriptionCultureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.productModelProductDescriptionCultureManager.Create(model);

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
		[ProducesResponseType(typeof(POCOProductModelProductDescriptionCulture), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ProductModelProductDescriptionCultureModel model)
		{
			try
			{
				ActionResponse result = await this.productModelProductDescriptionCultureManager.Update(id, model);

				if (result.Success)
				{
					POCOProductModelProductDescriptionCulture response = this.productModelProductDescriptionCultureManager.GetById(id).ProductModelProductDescriptionCultures.First();
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
			ActionResponse result = await this.productModelProductDescriptionCultureManager.Delete(id);

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
		[Route("ByCultureID/{id}")]
		[ReadOnly]
		[Route("~/api/Cultures/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOProductModelProductDescriptionCulture>), 200)]
		public virtual IActionResult ByCultureID(string id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureManager.GetWhere(x => x.CultureID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.ProductModelProductDescriptionCultures);
			}
		}

		[HttpGet]
		[Route("ByProductDescriptionID/{id}")]
		[ReadOnly]
		[Route("~/api/ProductDescriptions/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOProductModelProductDescriptionCulture>), 200)]
		public virtual IActionResult ByProductDescriptionID(int id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureManager.GetWhere(x => x.ProductDescriptionID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.ProductModelProductDescriptionCultures);
			}
		}

		[HttpGet]
		[Route("ByProductModelID/{id}")]
		[ReadOnly]
		[Route("~/api/ProductModels/{id}/ProductModelProductDescriptionCultures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOProductModelProductDescriptionCulture>), 200)]
		public virtual IActionResult ByProductModelID(int id)
		{
			ApiResponse response = this.productModelProductDescriptionCultureManager.GetWhere(x => x.ProductModelID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.ProductModelProductDescriptionCultures);
			}
		}
	}
}

/*<Codenesium>
    <Hash>933a58b1bc4a9583821aef08e2301fd0</Hash>
</Codenesium>*/