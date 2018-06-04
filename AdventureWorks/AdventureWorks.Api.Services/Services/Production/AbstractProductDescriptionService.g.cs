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
	public abstract class AbstractProductDescriptionService: AbstractService
	{
		private IProductDescriptionRepository productDescriptionRepository;
		private IApiProductDescriptionRequestModelValidator productDescriptionModelValidator;
		private IBOLProductDescriptionMapper BOLProductDescriptionMapper;
		private IDALProductDescriptionMapper DALProductDescriptionMapper;
		private ILogger logger;

		public AbstractProductDescriptionService(
			ILogger logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolproductDescriptionMapper,
			IDALProductDescriptionMapper dalproductDescriptionMapper)
			: base()

		{
			this.productDescriptionRepository = productDescriptionRepository;
			this.productDescriptionModelValidator = productDescriptionModelValidator;
			this.BOLProductDescriptionMapper = bolproductDescriptionMapper;
			this.DALProductDescriptionMapper = dalproductDescriptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productDescriptionRepository.All(skip, take, orderClause);

			return this.BOLProductDescriptionMapper.MapBOToModel(this.DALProductDescriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID)
		{
			var record = await productDescriptionRepository.Get(productDescriptionID);

			return this.BOLProductDescriptionMapper.MapBOToModel(this.DALProductDescriptionMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model)
		{
			CreateResponse<ApiProductDescriptionResponseModel> response = new CreateResponse<ApiProductDescriptionResponseModel>(await this.productDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductDescriptionMapper.MapModelToBO(default (int), model);
				var record = await this.productDescriptionRepository.Create(this.DALProductDescriptionMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductDescriptionMapper.MapBOToModel(this.DALProductDescriptionMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model));

			if (response.Success)
			{
				var bo = this.BOLProductDescriptionMapper.MapModelToBO(productDescriptionID, model);
				await this.productDescriptionRepository.Update(this.DALProductDescriptionMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));

			if (response.Success)
			{
				await this.productDescriptionRepository.Delete(productDescriptionID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>29ddb631d4cb9a012c6969f1dffc145f</Hash>
</Codenesium>*/