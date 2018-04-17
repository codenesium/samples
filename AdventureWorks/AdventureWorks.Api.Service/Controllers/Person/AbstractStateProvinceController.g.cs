using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractStateProvinceController: AbstractApiController
	{
		protected IBOStateProvince stateProvinceManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStateProvinceController(
			ILogger<AbstractStateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStateProvince stateProvinceManager
			)
			: base(logger, transactionCoordinator)
		{
			this.stateProvinceManager = stateProvinceManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.stateProvinceManager.GetById(id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.stateProvinceManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 400)]
		public virtual async Task<IActionResult> Create([FromBody] StateProvinceModel model)
		{
			var result = await this.stateProvinceManager.Create(model);

			if(result.Success)
			{
				return this.Ok(result);
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<StateProvinceModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				var result = await this.stateProvinceManager.Create(model);

				if(!result.Success)
				{
					return this.BadRequest(result);
				}
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] StateProvinceModel model)
		{
			var result = await this.stateProvinceManager.Update(id, model);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ActionResponse), 400)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var result = await this.stateProvinceManager.Delete(id);

			if(result.Success)
			{
				return this.Ok();
			}
			else
			{
				return this.BadRequest(result);
			}
		}

		[HttpGet]
		[Route("ByCountryRegionCode/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/CountryRegions/{id}/StateProvinces")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByCountryRegionCode(string id)
		{
			ApiResponse response = this.stateProvinceManager.GetWhere(x => x.CountryRegionCode == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByTerritoryID/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SalesTerritories/{id}/StateProvinces")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByTerritoryID(int id)
		{
			ApiResponse response = this.stateProvinceManager.GetWhere(x => x.TerritoryID == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>9c9f6e7948f12f538dec85aa7e1db5d4</Hash>
</Codenesium>*/