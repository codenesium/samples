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
	public abstract class AbstractProductProductPhotoService: AbstractService
	{
		private IProductProductPhotoRepository productProductPhotoRepository;
		private IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator;
		private IBOLProductProductPhotoMapper BOLProductProductPhotoMapper;
		private IDALProductProductPhotoMapper DALProductProductPhotoMapper;
		private ILogger logger;

		public AbstractProductProductPhotoService(
			ILogger logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
			IBOLProductProductPhotoMapper bolproductProductPhotoMapper,
			IDALProductProductPhotoMapper dalproductProductPhotoMapper)
			: base()

		{
			this.productProductPhotoRepository = productProductPhotoRepository;
			this.productProductPhotoModelValidator = productProductPhotoModelValidator;
			this.BOLProductProductPhotoMapper = bolproductProductPhotoMapper;
			this.DALProductProductPhotoMapper = dalproductProductPhotoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productProductPhotoRepository.All(skip, take, orderClause);

			return this.BOLProductProductPhotoMapper.MapBOToModel(this.DALProductProductPhotoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductProductPhotoResponseModel> Get(int productID)
		{
			var record = await productProductPhotoRepository.Get(productID);

			return this.BOLProductProductPhotoMapper.MapBOToModel(this.DALProductProductPhotoMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model)
		{
			CreateResponse<ApiProductProductPhotoResponseModel> response = new CreateResponse<ApiProductProductPhotoResponseModel>(await this.productProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductProductPhotoMapper.MapModelToBO(default (int), model);
				var record = await this.productProductPhotoRepository.Create(this.DALProductProductPhotoMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductProductPhotoMapper.MapBOToModel(this.DALProductProductPhotoMapper.MapEFToBO(record)));
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
				var bo = this.BOLProductProductPhotoMapper.MapModelToBO(productID, model);
				await this.productProductPhotoRepository.Update(this.DALProductProductPhotoMapper.MapBOToEF(bo));
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
    <Hash>baab9a3cebb8cff25d6ba298c781f97c</Hash>
</Codenesium>*/