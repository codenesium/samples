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
	public abstract class AbstractBOProductPhoto: AbstractBOManager
	{
		private IProductPhotoRepository productPhotoRepository;
		private IApiProductPhotoRequestModelValidator productPhotoModelValidator;
		private IBOLProductPhotoMapper productPhotoMapper;
		private ILogger logger;

		public AbstractBOProductPhoto(
			ILogger logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper productPhotoMapper)
			: base()

		{
			this.productPhotoRepository = productPhotoRepository;
			this.productPhotoModelValidator = productPhotoModelValidator;
			this.productPhotoMapper = productPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productPhotoRepository.All(skip, take, orderClause);

			return this.productPhotoMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductPhotoResponseModel> Get(int productPhotoID)
		{
			var record = await productPhotoRepository.Get(productPhotoID);

			return this.productPhotoMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
			ApiProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductPhotoResponseModel> response = new CreateResponse<ApiProductPhotoResponseModel>(await this.productPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productPhotoMapper.MapModelToDTO(default (int), model);
				var record = await this.productPhotoRepository.Create(dto);

				response.SetRecord(this.productPhotoMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productPhotoID,
			ApiProductPhotoRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model));

			if (response.Success)
			{
				var dto = this.productPhotoMapper.MapModelToDTO(productPhotoID, model);
				await this.productPhotoRepository.Update(productPhotoID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productPhotoID)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateDeleteAsync(productPhotoID));

			if (response.Success)
			{
				await this.productPhotoRepository.Delete(productPhotoID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>70b572601114e0ab4b10e0bf2e929fab</Hash>
</Codenesium>*/