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
		private IBillOfMaterialsModelValidator billOfMaterialsModelValidator;
		private ILogger logger;

		public AbstractBOBillOfMaterials(
			ILogger logger,
			IBillOfMaterialsRepository billOfMaterialsRepository,
			IBillOfMaterialsModelValidator billOfMaterialsModelValidator)

		{
			this.billOfMaterialsRepository = billOfMaterialsRepository;
			this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BillOfMaterialsModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.billOfMaterialsRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int billOfMaterialsID,
			BillOfMaterialsModel model)
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

		public virtual POCOBillOfMaterials Get(int billOfMaterialsID)
		{
			return this.billOfMaterialsRepository.Get(billOfMaterialsID);
		}

		public virtual List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.billOfMaterialsRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5fd53a95f82f7026444a09de0ceb91ad</Hash>
</Codenesium>*/