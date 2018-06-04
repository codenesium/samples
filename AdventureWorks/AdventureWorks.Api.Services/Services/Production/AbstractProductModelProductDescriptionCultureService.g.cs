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
	public abstract class AbstractProductModelProductDescriptionCultureService: AbstractService
	{
		private IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;
		private IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator;
		private IBOLProductModelProductDescriptionCultureMapper BOLProductModelProductDescriptionCultureMapper;
		private IDALProductModelProductDescriptionCultureMapper DALProductModelProductDescriptionCultureMapper;
		private ILogger logger;

		public AbstractProductModelProductDescriptionCultureService(
			ILogger logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
			IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper)
			: base()

		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
			this.BOLProductModelProductDescriptionCultureMapper = bolproductModelProductDescriptionCultureMapper;
			this.DALProductModelProductDescriptionCultureMapper = dalproductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productModelProductDescriptionCultureRepository.All(skip, take, orderClause);

			return this.BOLProductModelProductDescriptionCultureMapper.MapBOToModel(this.DALProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID)
		{
			var record = await productModelProductDescriptionCultureRepository.Get(productModelID);

			return this.BOLProductModelProductDescriptionCultureMapper.MapBOToModel(this.DALProductModelProductDescriptionCultureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductModelProductDescriptionCultureMapper.MapModelToBO(default (int), model);
				var record = await this.productModelProductDescriptionCultureRepository.Create(this.DALProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductModelProductDescriptionCultureMapper.MapBOToModel(this.DALProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				var bo = this.BOLProductModelProductDescriptionCultureMapper.MapModelToBO(productModelID, model);
				await this.productModelProductDescriptionCultureRepository.Update(this.DALProductModelProductDescriptionCultureMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelProductDescriptionCultureRepository.Delete(productModelID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d27dc351879eb40138e2f8f9d9ad503f</Hash>
</Codenesium>*/