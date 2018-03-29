using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractProductPhotoesController: AbstractEntityFrameworkApiController
	{
		protected IProductPhotoRepository _productPhotoRepository;
		protected IProductPhotoModelValidator _productPhotoModelValidator;
		protected int SearchRecordLimit {get; set;}
		protected int SearchRecordDefault {get; set;}
		public AbstractProductPhotoesController(
			ILogger<AbstractProductPhotoesController> logger,
			ApplicationContext context,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator
			) : base(logger,context)
		{
			this._productPhotoRepository = productPhotoRepository;
			this._productPhotoModelValidator = productPhotoModelValidator;
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
		[ProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Get(int id)
		{
			Response response = new Response();

			this._productPhotoRepository.GetById(id,response);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpGet]
		[Route("")]
		[ProductPhotoFilter]
		[ReadOnlyFilter]
		[ProducesResponseType(typeof(Response), 200)]
		public virtual IActionResult Search()
		{
			var query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			Response response = new Response();

			this._productPhotoRepository.GetWhereDynamic(query.WhereClause,response,query.Offset,query.Limit);
			response.DisableSerializationOfEmptyFields();
			return Ok(response);
		}

		[HttpPost]
		[Route("")]
		[ModelValidateFilter]
		[ProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(int), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Create(ProductPhotoModel model)
		{
			this._productPhotoModelValidator.CreateMode();
			var validationResult = this._productPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				var id = this._productPhotoRepository.Create(model.ThumbNailPhoto,
				                                             model.ThumbnailPhotoFileName,
				                                             model.LargePhoto,
				                                             model.LargePhotoFileName,
				                                             model.ModifiedDate);
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
		[ProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult CreateMany(List<ProductPhotoModel> models)
		{
			this._productPhotoModelValidator.CreateMode();
			foreach(var model in models)
			{
				var validationResult = this._productPhotoModelValidator.Validate(model);
				if(!validationResult.IsValid)
				{
					AddErrors(validationResult);
					return BadRequest(this.ModelState);
				}
			}

			foreach(var model in models)
			{
				this._productPhotoRepository.Create(model.ThumbNailPhoto,
				                                    model.ThumbnailPhotoFileName,
				                                    model.LargePhoto,
				                                    model.LargePhotoFileName,
				                                    model.ModifiedDate);
			}
			return Ok();
		}

		[HttpPut]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		[ProducesResponseType(typeof(ModelStateDictionary), 400)]
		public virtual IActionResult Update(int ProductPhotoID,ProductPhotoModel model)
		{
			this._productPhotoModelValidator.UpdateMode();
			var validationResult = this._productPhotoModelValidator.Validate(model);
			if (validationResult.IsValid)
			{
				this._productPhotoRepository.Update(ProductPhotoID,  model.ThumbNailPhoto,
				                                    model.ThumbnailPhotoFileName,
				                                    model.LargePhoto,
				                                    model.LargePhotoFileName,
				                                    model.ModifiedDate);
				return Ok();
			}
			else
			{
				AddErrors(validationResult);
				return BadRequest(this.ModelState);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[ModelValidateFilter]
		[ProductPhotoFilter]
		[UnitOfWorkActionFilter]
		[ProducesResponseType(typeof(void), 200)]
		public virtual IActionResult Delete(int id)
		{
			this._productPhotoRepository.Delete(id);
			return Ok();
		}
	}
}

/*<Codenesium>
    <Hash>46188a93e0b62e66e275b14e84cb933c</Hash>
</Codenesium>*/