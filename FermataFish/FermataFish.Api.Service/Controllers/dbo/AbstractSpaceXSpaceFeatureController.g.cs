using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public abstract class AbstractSpaceXSpaceFeatureController: AbstractApiController
	{
		protected ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractSpaceXSpaceFeatureController(
			ILogger<AbstractSpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureRepository.GetById(id);
			response.DisableSerializationOfEmptyFields();
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
			ApiResponse response = this.spaceXSpaceFeatureRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] SpaceXSpaceFeatureModel model)
		{
			var id = this.spaceXSpaceFeatureRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<SpaceXSpaceFeatureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.spaceXSpaceFeatureRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] SpaceXSpaceFeatureModel model)
		{
			this.spaceXSpaceFeatureRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.spaceXSpaceFeatureRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("BySpaceId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Spaces/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureRepository.GetWhere(x => x.SpaceId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("BySpaceFeatureId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/SpaceFeatures/{id}/SpaceXSpaceFeatures")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult BySpaceFeatureId(int id)
		{
			ApiResponse response = this.spaceXSpaceFeatureRepository.GetWhere(x => x.SpaceFeatureId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>aa405e2c79608aa7569a3c5c14f80ca3</Hash>
</Codenesium>*/