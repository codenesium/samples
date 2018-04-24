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
	public abstract class AbstractBusinessEntityAddressController: AbstractApiController
	{
		protected IBOBusinessEntityAddress businessEntityAddressManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractBusinessEntityAddressController(
			ServiceSettings settings,
			ILogger<AbstractBusinessEntityAddressController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBusinessEntityAddress businessEntityAddressManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.businessEntityAddressManager = businessEntityAddressManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOBusinessEntityAddress), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOBusinessEntityAddress response = this.businessEntityAddressManager.GetById(id).BusinessEntityAddresses.FirstOrDefault();
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
		[ProducesResponseType(typeof(List<POCOBusinessEntityAddress>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.businessEntityAddressManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.BusinessEntityAddresses);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOBusinessEntityAddress), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] BusinessEntityAddressModel model)
		{
			CreateResponse<int> result = await this.businessEntityAddressManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/businessEntityAddresses/{result.Id.ToString()}");
				POCOBusinessEntityAddress response = this.businessEntityAddressManager.GetById(result.Id).BusinessEntityAddresses.First();
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
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<BusinessEntityAddressModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.businessEntityAddressManager.Create(model);

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
		[ProducesResponseType(typeof(POCOBusinessEntityAddress), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] BusinessEntityAddressModel model)
		{
			try
			{
				ActionResponse result = await this.businessEntityAddressManager.Update(id, model);

				if (result.Success)
				{
					POCOBusinessEntityAddress response = this.businessEntityAddressManager.GetById(id).BusinessEntityAddresses.First();
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
			ActionResponse result = await this.businessEntityAddressManager.Delete(id);

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
		[Route("ByBusinessEntityID/{id}")]
		[ReadOnly]
		[Route("~/api/BusinessEntities/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOBusinessEntityAddress>), 200)]
		public virtual IActionResult ByBusinessEntityID(int id)
		{
			ApiResponse response = this.businessEntityAddressManager.GetWhere(x => x.BusinessEntityID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.BusinessEntityAddresses);
			}
		}

		[HttpGet]
		[Route("ByAddressID/{id}")]
		[ReadOnly]
		[Route("~/api/Addresses/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOBusinessEntityAddress>), 200)]
		public virtual IActionResult ByAddressID(int id)
		{
			ApiResponse response = this.businessEntityAddressManager.GetWhere(x => x.AddressID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.BusinessEntityAddresses);
			}
		}

		[HttpGet]
		[Route("ByAddressTypeID/{id}")]
		[ReadOnly]
		[Route("~/api/AddressTypes/{id}/BusinessEntityAddresses")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOBusinessEntityAddress>), 200)]
		public virtual IActionResult ByAddressTypeID(int id)
		{
			ApiResponse response = this.businessEntityAddressManager.GetWhere(x => x.AddressTypeID == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.BusinessEntityAddresses);
			}
		}
	}
}

/*<Codenesium>
    <Hash>22c608597b4102ecbb1007820bfaa619</Hash>
</Codenesium>*/