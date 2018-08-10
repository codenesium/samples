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
	public abstract class AbstractProductProductPhotoService : AbstractService
	{
		protected IProductProductPhotoRepository ProductProductPhotoRepository { get; private set; }

		protected IApiProductProductPhotoRequestModelValidator ProductProductPhotoModelValidator { get; private set; }

		protected IBOLProductProductPhotoMapper BolProductProductPhotoMapper { get; private set; }

		protected IDALProductProductPhotoMapper DalProductProductPhotoMapper { get; private set; }

		private ILogger logger;

		public AbstractProductProductPhotoService(
			ILogger logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base()
		{
			this.ProductProductPhotoRepository = productProductPhotoRepository;
			this.ProductProductPhotoModelValidator = productProductPhotoModelValidator;
			this.BolProductProductPhotoMapper = bolProductProductPhotoMapper;
			this.DalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductProductPhotoRepository.All(limit, offset);

			return this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> Get(int productID)
		{
			var record = await this.ProductProductPhotoRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductProductPhotoResponseModel> response = new CreateResponse<ApiProductProductPhotoResponseModel>(await this.ProductProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductProductPhotoMapper.MapModelToBO(default(int), model);
				var record = await this.ProductProductPhotoRepository.Create(this.DalProductProductPhotoMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductProductPhotoResponseModel>> Update(
			int productID,
			ApiProductProductPhotoRequestModel model)
		{
			var validationResult = await this.ProductProductPhotoModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductProductPhotoMapper.MapModelToBO(productID, model);
				await this.ProductProductPhotoRepository.Update(this.DalProductProductPhotoMapper.MapBOToEF(bo));

				var record = await this.ProductProductPhotoRepository.Get(productID);

				return new UpdateResponse<ApiProductProductPhotoResponseModel>(this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductProductPhotoResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductProductPhotoModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductProductPhotoRepository.Delete(productID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4c4843c349e6234fa6bb957ed82504e6</Hash>
</Codenesium>*/