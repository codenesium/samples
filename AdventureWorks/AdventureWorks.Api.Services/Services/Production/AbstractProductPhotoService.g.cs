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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductPhotoService: AbstractService
	{
		private IProductPhotoRepository productPhotoRepository;
		private IApiProductPhotoRequestModelValidator productPhotoModelValidator;
		private IBOLProductPhotoMapper bolProductPhotoMapper;
		private IDALProductPhotoMapper dalProductPhotoMapper;
		private ILogger logger;

		public AbstractProductPhotoService(
			ILogger logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolproductPhotoMapper,
			IDALProductPhotoMapper dalproductPhotoMapper)
			: base()

		{
			this.productPhotoRepository = productPhotoRepository;
			this.productPhotoModelValidator = productPhotoModelValidator;
			this.bolProductPhotoMapper = bolproductPhotoMapper;
			this.dalProductPhotoMapper = dalproductPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productPhotoRepository.All(skip, take, orderClause);

			return this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductPhotoResponseModel> Get(int productPhotoID)
		{
			var record = await productPhotoRepository.Get(productPhotoID);

			return this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
			ApiProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductPhotoResponseModel> response = new CreateResponse<ApiProductPhotoResponseModel>(await this.productPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolProductPhotoMapper.MapModelToBO(default (int), model);
				var record = await this.productPhotoRepository.Create(this.dalProductPhotoMapper.MapBOToEF(bo));

				response.SetRecord(this.bolProductPhotoMapper.MapBOToModel(this.dalProductPhotoMapper.MapEFToBO(record)));
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
				var bo = this.bolProductPhotoMapper.MapModelToBO(productPhotoID, model);
				await this.productPhotoRepository.Update(this.dalProductPhotoMapper.MapBOToEF(bo));
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
    <Hash>99596bd4cbd771be65e5350637c973f4</Hash>
</Codenesium>*/