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
	public abstract class AbstractBOBusinessEntityAddress: AbstractBOManager
	{
		private IBusinessEntityAddressRepository businessEntityAddressRepository;
		private IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator;
		private IBOLBusinessEntityAddressMapper businessEntityAddressMapper;
		private ILogger logger;

		public AbstractBOBusinessEntityAddress(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
			IBOLBusinessEntityAddressMapper businessEntityAddressMapper)
			: base()

		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
			this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.businessEntityAddressMapper = businessEntityAddressMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityAddressRepository.All(skip, take, orderClause);

			return this.businessEntityAddressMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityAddressRepository.Get(businessEntityID);

			return this.businessEntityAddressMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
			ApiBusinessEntityAddressRequestModel model)
		{
			CreateResponse<ApiBusinessEntityAddressResponseModel> response = new CreateResponse<ApiBusinessEntityAddressResponseModel>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.businessEntityAddressMapper.MapModelToDTO(default (int), model);
				var record = await this.businessEntityAddressRepository.Create(dto);

				response.SetRecord(this.businessEntityAddressMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.businessEntityAddressMapper.MapModelToDTO(businessEntityID, model);
				await this.businessEntityAddressRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressID(int addressID)
		{
			List<DTOBusinessEntityAddress> records = await this.businessEntityAddressRepository.GetAddressID(addressID);

			return this.businessEntityAddressMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressTypeID(int addressTypeID)
		{
			List<DTOBusinessEntityAddress> records = await this.businessEntityAddressRepository.GetAddressTypeID(addressTypeID);

			return this.businessEntityAddressMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5163eda3ad55f65d5836ec85927bb81d</Hash>
</Codenesium>*/