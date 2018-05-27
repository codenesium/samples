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
	public abstract class AbstractBOShipMethod: AbstractBOManager
	{
		private IShipMethodRepository shipMethodRepository;
		private IApiShipMethodRequestModelValidator shipMethodModelValidator;
		private IBOLShipMethodMapper shipMethodMapper;
		private ILogger logger;

		public AbstractBOShipMethod(
			ILogger logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper shipMethodMapper)
			: base()

		{
			this.shipMethodRepository = shipMethodRepository;
			this.shipMethodModelValidator = shipMethodModelValidator;
			this.shipMethodMapper = shipMethodMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shipMethodRepository.All(skip, take, orderClause);

			return this.shipMethodMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiShipMethodResponseModel> Get(int shipMethodID)
		{
			var record = await shipMethodRepository.Get(shipMethodID);

			return this.shipMethodMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiShipMethodResponseModel>> Create(
			ApiShipMethodRequestModel model)
		{
			CreateResponse<ApiShipMethodResponseModel> response = new CreateResponse<ApiShipMethodResponseModel>(await this.shipMethodModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.shipMethodMapper.MapModelToDTO(default (int), model);
				var record = await this.shipMethodRepository.Create(dto);

				response.SetRecord(this.shipMethodMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shipMethodID,
			ApiShipMethodRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model));

			if (response.Success)
			{
				var dto = this.shipMethodMapper.MapModelToDTO(shipMethodID, model);
				await this.shipMethodRepository.Update(shipMethodID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shipMethodID)
		{
			ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateDeleteAsync(shipMethodID));

			if (response.Success)
			{
				await this.shipMethodRepository.Delete(shipMethodID);
			}
			return response;
		}

		public async Task<ApiShipMethodResponseModel> GetName(string name)
		{
			DTOShipMethod record = await this.shipMethodRepository.GetName(name);

			return this.shipMethodMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>42a42fa2acfa40c26883ce29d2ea24ef</Hash>
</Codenesium>*/