using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractStateProvinceService : AbstractService
	{
		private IMediator mediator;

		protected IStateProvinceRepository StateProvinceRepository { get; private set; }

		protected IApiStateProvinceServerRequestModelValidator StateProvinceModelValidator { get; private set; }

		protected IDALStateProvinceMapper DalStateProvinceMapper { get; private set; }

		protected IDALAddressMapper DalAddressMapper { get; private set; }

		private ILogger logger;

		public AbstractStateProvinceService(
			ILogger logger,
			IMediator mediator,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceServerRequestModelValidator stateProvinceModelValidator,
			IDALStateProvinceMapper dalStateProvinceMapper,
			IDALAddressMapper dalAddressMapper)
			: base()
		{
			this.StateProvinceRepository = stateProvinceRepository;
			this.StateProvinceModelValidator = stateProvinceModelValidator;
			this.DalStateProvinceMapper = dalStateProvinceMapper;
			this.DalAddressMapper = dalAddressMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStateProvinceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.StateProvinceRepository.All(limit, offset, query);

			return this.DalStateProvinceMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiStateProvinceServerResponseModel> Get(int stateProvinceID)
		{
			var record = await this.StateProvinceRepository.Get(stateProvinceID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStateProvinceMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiStateProvinceServerResponseModel>> Create(
			ApiStateProvinceServerRequestModel model)
		{
			CreateResponse<ApiStateProvinceServerResponseModel> response = ValidationResponseFactory<ApiStateProvinceServerResponseModel>.CreateResponse(await this.StateProvinceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalStateProvinceMapper.MapModelToBO(default(int), model);
				var record = await this.StateProvinceRepository.Create(bo);

				response.SetRecord(this.DalStateProvinceMapper.MapBOToModel(record));
				await this.mediator.Publish(new StateProvinceCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStateProvinceServerResponseModel>> Update(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel model)
		{
			var validationResult = await this.StateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalStateProvinceMapper.MapModelToBO(stateProvinceID, model);
				await this.StateProvinceRepository.Update(bo);

				var record = await this.StateProvinceRepository.Get(stateProvinceID);

				var apiModel = this.DalStateProvinceMapper.MapBOToModel(record);
				await this.mediator.Publish(new StateProvinceUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiStateProvinceServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiStateProvinceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));

			if (response.Success)
			{
				await this.StateProvinceRepository.Delete(stateProvinceID);

				await this.mediator.Publish(new StateProvinceDeletedNotification(stateProvinceID));
			}

			return response;
		}

		public async virtual Task<ApiStateProvinceServerResponseModel> ByName(string name)
		{
			StateProvince record = await this.StateProvinceRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStateProvinceMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<ApiStateProvinceServerResponseModel> ByRowguid(Guid rowguid)
		{
			StateProvince record = await this.StateProvinceRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStateProvinceMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<ApiStateProvinceServerResponseModel> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			StateProvince record = await this.StateProvinceRepository.ByStateProvinceCodeCountryRegionCode(stateProvinceCode, countryRegionCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStateProvinceMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiAddressServerResponseModel>> AddressesByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
		{
			List<Address> records = await this.StateProvinceRepository.AddressesByStateProvinceID(stateProvinceID, limit, offset);

			return this.DalAddressMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>fe79e5464b4658aca3818ed8719237f4</Hash>
</Codenesium>*/