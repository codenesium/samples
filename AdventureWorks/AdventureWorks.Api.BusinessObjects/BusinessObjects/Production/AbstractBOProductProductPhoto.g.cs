using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductProductPhoto: AbstractBOManager
	{
		private IProductProductPhotoRepository productProductPhotoRepository;
		private IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator;
		private IBOLProductProductPhotoMapper productProductPhotoMapper;
		private ILogger logger;

		public AbstractBOProductProductPhoto(
			ILogger logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper productProductPhotoMapper)
			: base()

		{
			this.productProductPhotoRepository = productProductPhotoRepository;
			this.productProductPhotoModelValidator = productProductPhotoModelValidator;
			this.productProductPhotoMapper = productProductPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productProductPhotoRepository.All(skip, take, orderClause);

			return this.productProductPhotoMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> Get(int productID)
		{
			var record = await productProductPhotoRepository.Get(productID);

			return this.productProductPhotoMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductProductPhotoResponseModel> response = new CreateResponse<ApiProductProductPhotoResponseModel>(await this.productProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productProductPhotoMapper.MapModelToDTO(default (int), model);
				var record = await this.productProductPhotoRepository.Create(dto);

				response.SetRecord(this.productProductPhotoMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductProductPhotoRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productProductPhotoMapper.MapModelToDTO(productID, model);
				await this.productProductPhotoRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productProductPhotoRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d7eaddf1ab677a17b01da6fd1921a771</Hash>
</Codenesium>*/