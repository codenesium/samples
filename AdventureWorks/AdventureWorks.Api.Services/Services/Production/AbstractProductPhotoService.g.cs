using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductPhotoService : AbstractService
	{
		protected IProductPhotoRepository ProductPhotoRepository { get; private set; }

		protected IApiProductPhotoRequestModelValidator ProductPhotoModelValidator { get; private set; }

		protected IBOLProductPhotoMapper BolProductPhotoMapper { get; private set; }

		protected IDALProductPhotoMapper DalProductPhotoMapper { get; private set; }

		protected IBOLProductProductPhotoMapper BolProductProductPhotoMapper { get; private set; }

		protected IDALProductProductPhotoMapper DalProductProductPhotoMapper { get; private set; }

		private ILogger logger;

		public AbstractProductPhotoService(
			ILogger logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolProductPhotoMapper,
			IDALProductPhotoMapper dalProductPhotoMapper,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base()
		{
			this.ProductPhotoRepository = productPhotoRepository;
			this.ProductPhotoModelValidator = productPhotoModelValidator;
			this.BolProductPhotoMapper = bolProductPhotoMapper;
			this.DalProductPhotoMapper = dalProductPhotoMapper;
			this.BolProductProductPhotoMapper = bolProductProductPhotoMapper;
			this.DalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductPhotoResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductPhotoRepository.All(limit, offset);

			return this.BolProductPhotoMapper.MapBOToModel(this.DalProductPhotoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductPhotoResponseModel> Get(int productPhotoID)
		{
			var record = await this.ProductPhotoRepository.Get(productPhotoID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductPhotoMapper.MapBOToModel(this.DalProductPhotoMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
			ApiProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductPhotoResponseModel> response = new CreateResponse<ApiProductPhotoResponseModel>(await this.ProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductPhotoMapper.MapModelToBO(default(int), model);
				var record = await this.ProductPhotoRepository.Create(this.DalProductPhotoMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductPhotoMapper.MapBOToModel(this.DalProductPhotoMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductPhotoResponseModel>> Update(
			int productPhotoID,
			ApiProductPhotoRequestModel model)
		{
			var validationResult = await this.ProductPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductPhotoMapper.MapModelToBO(productPhotoID, model);
				await this.ProductPhotoRepository.Update(this.DalProductPhotoMapper.MapBOToEF(bo));

				var record = await this.ProductPhotoRepository.Get(productPhotoID);

				return new UpdateResponse<ApiProductPhotoResponseModel>(this.BolProductPhotoMapper.MapBOToModel(this.DalProductPhotoMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductPhotoResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productPhotoID)
		{
			ActionResponse response = new ActionResponse(await this.ProductPhotoModelValidator.ValidateDeleteAsync(productPhotoID));
			if (response.Success)
			{
				await this.ProductPhotoRepository.Delete(productPhotoID);
			}

			return response;
		}

		public async virtual Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoesByProductPhotoID(int productPhotoID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductProductPhoto> records = await this.ProductPhotoRepository.ProductProductPhotoesByProductPhotoID(productPhotoID, limit, offset);

			return this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ef7840a51f9aa454c666e0da40d65651</Hash>
</Codenesium>*/