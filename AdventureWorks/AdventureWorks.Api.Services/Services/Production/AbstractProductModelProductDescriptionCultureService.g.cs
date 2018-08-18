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
	public abstract class AbstractProductModelProductDescriptionCultureService : AbstractService
	{
		protected IProductModelProductDescriptionCultureRepository ProductModelProductDescriptionCultureRepository { get; private set; }

		protected IApiProductModelProductDescriptionCultureRequestModelValidator ProductModelProductDescriptionCultureModelValidator { get; private set; }

		protected IBOLProductModelProductDescriptionCultureMapper BolProductModelProductDescriptionCultureMapper { get; private set; }

		protected IDALProductModelProductDescriptionCultureMapper DalProductModelProductDescriptionCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractProductModelProductDescriptionCultureService(
			ILogger logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base()
		{
			this.ProductModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.ProductModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
			this.BolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
			this.DalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductModelProductDescriptionCultureRepository.All(limit, offset);

			return this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID)
		{
			var record = await this.ProductModelProductDescriptionCultureRepository.Get(productModelID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(await this.ProductModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductModelProductDescriptionCultureMapper.MapModelToBO(default(int), model);
				var record = await this.ProductModelProductDescriptionCultureRepository.Create(this.DalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			var validationResult = await this.ProductModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductModelProductDescriptionCultureMapper.MapModelToBO(productModelID, model);
				await this.ProductModelProductDescriptionCultureRepository.Update(this.DalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

				var record = await this.ProductModelProductDescriptionCultureRepository.Get(productModelID);

				return new UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>(this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.ProductModelProductDescriptionCultureModelValidator.ValidateDeleteAsync(productModelID));
			if (response.Success)
			{
				await this.ProductModelProductDescriptionCultureRepository.Delete(productModelID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8294a75aec123ef86e24829f38eb8d17</Hash>
</Codenesium>*/