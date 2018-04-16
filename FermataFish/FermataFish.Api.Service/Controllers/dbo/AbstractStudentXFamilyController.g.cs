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
	public abstract class AbstractStudentXFamilyController: AbstractApiController
	{
		protected IStudentXFamilyRepository studentXFamilyRepository;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractStudentXFamilyController(
			ILogger<AbstractStudentXFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentXFamilyRepository studentXFamilyRepository
			)
			: base(logger, transactionCoordinator)
		{
			this.studentXFamilyRepository = studentXFamilyRepository;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult Get(int id)
		{
			ApiResponse response = this.studentXFamilyRepository.GetById(id);
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
			ApiResponse response = this.studentXFamilyRepository.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create([FromBody] StudentXFamilyModel model)
		{
			var id = this.studentXFamilyRepository.Create(model);
			return this.Ok(id);
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult BulkInsert([FromBody] List<StudentXFamilyModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				throw new Exception($"Request exceeds maximum record limit of {this.BulkInsertLimit}");
			}

			foreach (var model in models)
			{
				this.studentXFamilyRepository.Create(model);
			}

			return this.Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int id, [FromBody] StudentXFamilyModel model)
		{
			this.studentXFamilyRepository.Update(id, model);
			return this.Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this.studentXFamilyRepository.Delete(id);
			return this.Ok();
		}

		[HttpGet]
		[Route("ByStudentId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Students/{id}/StudentXFamilies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByStudentId(int id)
		{
			ApiResponse response = this.studentXFamilyRepository.GetWhere(x => x.StudentId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}

		[HttpGet]
		[Route("ByFamilyId/{id}")]
		[ReadOnlyFilter]
		[Route("~/api/Families/{id}/StudentXFamilies")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		public virtual IActionResult ByFamilyId(int id)
		{
			ApiResponse response = this.studentXFamilyRepository.GetWhere(x => x.FamilyId == id);
			response.DisableSerializationOfEmptyFields();
			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>532707b5ef648bede58a5ab999a4b0a4</Hash>
</Codenesium>*/