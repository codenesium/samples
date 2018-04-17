using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public abstract class AbstractFileController: AbstractApiController
	{
		protected IFileRepository fileRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractFileController(
			ILogger<AbstractFileController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFileRepository fileRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.fileRepository = fileRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.fileRepository.GetById(id);
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
			ApiResponse response = this.fileRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] FileModel model)
		{
			var id = this.fileRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<FileModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.fileRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] FileModel model)
		{
			this.fileRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.fileRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByFileTypeId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/FileTypes/{id}/Files")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByFileTypeId(int id)
		{
			ApiResponse response = this.fileRepository.GetWhere(x => x.FileTypeId == id);
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByBucketId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Buckets/{id}/Files")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByBucketId(int id)
		{
			ApiResponse response = this.fileRepository.GetWhere(x => x.BucketId == id);
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>45c5af2dafd97623f8aea639c7e4cf23</Hash>
</Codenesium>*/