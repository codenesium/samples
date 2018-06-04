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
	public abstract class AbstractBillOfMaterialsService: AbstractService
	{
		private IBillOfMaterialsRepository billOfMaterialsRepository;
		private IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator;
		private IBOLBillOfMaterialsMapper BOLBillOfMaterialsMapper;
		private IDALBillOfMaterialsMapper DALBillOfMaterialsMapper;
		private ILogger logger;

		public AbstractBillOfMaterialsService(
			ILogger logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
			IBOLBillOfMaterialsMapper bolbillOfMaterialsMapper,
			IDALBillOfMaterialsMapper dalbillOfMaterialsMapper)
			: base()

		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
			this.BOLBillOfMaterialsMapper = bolbillOfMaterialsMapper;
			this.DALBillOfMaterialsMapper = dalbillOfMaterialsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBillOfMaterialsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.billOfMaterialsRepository.All(skip, take, orderClause);

			return this.BOLBillOfMaterialsMapper.MapBOToModel(this.DALBillOfMaterialsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> Get(int billOfMaterialsID)
		{
			var record = await billOfMaterialsRepository.Get(billOfMaterialsID);

			return this.BOLBillOfMaterialsMapper.MapBOToModel(this.DALBillOfMaterialsMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialsResponseModel>> Create(
			ApiBillOfMaterialsRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialsResponseModel> response = new CreateResponse<ApiBillOfMaterialsResponseModel>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBillOfMaterialsMapper.MapModelToBO(default (int), model);
				var record = await this.billOfMaterialsRepository.Create(this.DALBillOfMaterialsMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBillOfMaterialsMapper.MapBOToModel(this.DALBillOfMaterialsMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int billOfMaterialsID,
			ApiBillOfMaterialsRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateUpdateAsync(billOfMaterialsID, model));

			if (response.Success)
			{
				var bo = this.BOLBillOfMaterialsMapper.MapModelToBO(billOfMaterialsID, model);
				await this.billOfMaterialsRepository.Update(this.DALBillOfMaterialsMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int billOfMaterialsID)
		{
			ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateDeleteAsync(billOfMaterialsID));

			if (response.Success)
			{
				await this.billOfMaterialsRepository.Delete(billOfMaterialsID);
			}
			return response;
		}

		public async Task<ApiBillOfMaterialsResponseModel> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			BillOfMaterials record = await this.billOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);

			return this.BOLBillOfMaterialsMapper.MapBOToModel(this.DALBillOfMaterialsMapper.MapEFToBO(record));
		}
		public async Task<List<ApiBillOfMaterialsResponseModel>> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<BillOfMaterials> records = await this.billOfMaterialsRepository.GetUnitMeasureCode(unitMeasureCode);

			return this.BOLBillOfMaterialsMapper.MapBOToModel(this.DALBillOfMaterialsMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>73af3779689cab9d0513ae4ecc8dd242</Hash>
</Codenesium>*/