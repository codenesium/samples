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
	public abstract class AbstractBOBillOfMaterials: AbstractBOManager
	{
		private IBillOfMaterialsRepository billOfMaterialsRepository;
		private IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator;
		private IBOLBillOfMaterialsMapper billOfMaterialsMapper;
		private ILogger logger;

		public AbstractBOBillOfMaterials(
			ILogger logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
			IBOLBillOfMaterialsMapper billOfMaterialsMapper)
			: base()

		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
			this.billOfMaterialsMapper = billOfMaterialsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBillOfMaterialsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.billOfMaterialsRepository.All(skip, take, orderClause);

			return this.billOfMaterialsMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBillOfMaterialsResponseModel> Get(int billOfMaterialsID)
		{
			var record = await billOfMaterialsRepository.Get(billOfMaterialsID);

			return this.billOfMaterialsMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialsResponseModel>> Create(
			ApiBillOfMaterialsRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialsResponseModel> response = new CreateResponse<ApiBillOfMaterialsResponseModel>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.billOfMaterialsMapper.MapModelToDTO(default (int), model);
				var record = await this.billOfMaterialsRepository.Create(dto);

				response.SetRecord(this.billOfMaterialsMapper.MapDTOToModel(record));
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
				var dto = this.billOfMaterialsMapper.MapModelToDTO(billOfMaterialsID, model);
				await this.billOfMaterialsRepository.Update(billOfMaterialsID, dto);
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
			DTOBillOfMaterials record = await this.billOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);

			return this.billOfMaterialsMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiBillOfMaterialsResponseModel>> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<DTOBillOfMaterials> records = await this.billOfMaterialsRepository.GetUnitMeasureCode(unitMeasureCode);

			return this.billOfMaterialsMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e9a00ffcd7ed24f82f6c43c3e3fb9430</Hash>
</Codenesium>*/