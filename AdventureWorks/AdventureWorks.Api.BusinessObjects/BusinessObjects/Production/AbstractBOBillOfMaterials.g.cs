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
		private IApiBillOfMaterialsModelValidator billOfMaterialsModelValidator;
		private ILogger logger;

		public AbstractBOBillOfMaterials(
			ILogger logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsModelValidator billOfMaterialsModelValidator)
			: base()

		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.billOfMaterialsRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOBillOfMaterials> Get(int billOfMaterialsID)
		{
			return this.billOfMaterialsRepository.Get(billOfMaterialsID);
		}

		public virtual async Task<CreateResponse<POCOBillOfMaterials>> Create(
			ApiBillOfMaterialsModel model)
		{
			CreateResponse<POCOBillOfMaterials> response = new CreateResponse<POCOBillOfMaterials>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBillOfMaterials record = await this.billOfMaterialsRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int billOfMaterialsID,
			ApiBillOfMaterialsModel model)
		{
			ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateUpdateAsync(billOfMaterialsID, model));

			if (response.Success)
			{
				await this.billOfMaterialsRepository.Update(billOfMaterialsID, model);
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

		public async Task<POCOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			return await this.billOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);
		}
		public async Task<List<POCOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode)
		{
			return await this.billOfMaterialsRepository.GetUnitMeasureCode(unitMeasureCode);
		}
	}
}

/*<Codenesium>
    <Hash>369d758718f2c5bb6b600c437c8a9734</Hash>
</Codenesium>*/