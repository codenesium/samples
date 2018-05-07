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
		private IShipMethodModelValidator shipMethodModelValidator;
		private ILogger logger;

		public AbstractBOShipMethod(
			ILogger logger,
			IShipMethodRepository shipMethodRepository,
			IShipMethodModelValidator shipMethodModelValidator)

		{
			this.shipMethodRepository = shipMethodRepository;
			this.shipMethodModelValidator = shipMethodModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ShipMethodModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.shipMethodModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.shipMethodRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shipMethodID,
			ShipMethodModel model)
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

		public virtual POCOShipMethod Get(int shipMethodID)
		{
			return this.shipMethodRepository.Get(shipMethodID);
		}

		public virtual List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shipMethodRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d942625dd710dbb0bafb6ebf41c7ce0a</Hash>
</Codenesium>*/