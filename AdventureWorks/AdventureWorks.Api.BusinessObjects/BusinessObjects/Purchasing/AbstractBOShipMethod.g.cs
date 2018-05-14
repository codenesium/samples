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
	public abstract class AbstractBOShipMethod
	{
		private IShipMethodRepository shipMethodRepository;
		private IApiShipMethodModelValidator shipMethodModelValidator;
		private ILogger logger;

		public AbstractBOShipMethod(
			ILogger logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodModelValidator shipMethodModelValidator)

		{
			this.shipMethodRepository = shipMethodRepository;
			this.shipMethodModelValidator = shipMethodModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shipMethodRepository.All(skip, take, orderClause);
		}

		public virtual POCOShipMethod Get(int shipMethodID)
		{
			return this.shipMethodRepository.Get(shipMethodID);
		}

		public virtual async Task<CreateResponse<POCOShipMethod>> Create(
			ApiShipMethodModel model)
		{
			CreateResponse<POCOShipMethod> response = new CreateResponse<POCOShipMethod>(await this.shipMethodModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOShipMethod record = this.shipMethodRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shipMethodID,
			ApiShipMethodModel model)
		{
			ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model));

			if (response.Success)
			{
				this.shipMethodRepository.Update(shipMethodID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shipMethodID)
		{
			ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateDeleteAsync(shipMethodID));

			if (response.Success)
			{
				this.shipMethodRepository.Delete(shipMethodID);
			}
			return response;
		}

		public POCOShipMethod GetName(string name)
		{
			return this.shipMethodRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>df509b8e359f0dc618b0262f2fc98cc7</Hash>
</Codenesium>*/