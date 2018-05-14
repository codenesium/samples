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
	public abstract class AbstractBOBillOfMaterials
	{
		private IBillOfMaterialsRepository billOfMaterialsRepository;
		private IApiBillOfMaterialsModelValidator billOfMaterialsModelValidator;
		private ILogger logger;

		public AbstractBOBillOfMaterials(
			ILogger logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IApiBillOfMaterialsModelValidator billOfMaterialsModelValidator)

		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.billOfMaterialsRepository.All(skip, take, orderClause);
		}

		public virtual POCOBillOfMaterials Get(int billOfMaterialsID)
		{
			return this.billOfMaterialsRepository.Get(billOfMaterialsID);
		}

		public virtual async Task<CreateResponse<POCOBillOfMaterials>> Create(
			ApiBillOfMaterialsModel model)
		{
			CreateResponse<POCOBillOfMaterials> response = new CreateResponse<POCOBillOfMaterials>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBillOfMaterials record = this.billOfMaterialsRepository.Create(model);
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
				this.billOfMaterialsRepository.Update(billOfMaterialsID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int billOfMaterialsID)
		{
			ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateDeleteAsync(billOfMaterialsID));

			if (response.Success)
			{
				this.billOfMaterialsRepository.Delete(billOfMaterialsID);
			}
			return response;
		}

		public POCOBillOfMaterials GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			return this.billOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(productAssemblyID,componentID,startDate);
		}

		public List<POCOBillOfMaterials> GetUnitMeasureCode(string unitMeasureCode)
		{
			return this.billOfMaterialsRepository.GetUnitMeasureCode(unitMeasureCode);
		}
	}
}

/*<Codenesium>
    <Hash>6718975b9f6985ae14a1da1e06675dab</Hash>
</Codenesium>*/