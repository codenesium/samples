using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractLocationService : AbstractService
	{
		private IMediator mediator;

		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationServerRequestModelValidator LocationModelValidator { get; private set; }

		protected IBOLLocationMapper BolLocationMapper { get; private set; }

		protected IDALLocationMapper DalLocationMapper { get; private set; }

		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			IMediator mediator,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper)
			: base()
		{
			this.LocationRepository = locationRepository;
			this.LocationModelValidator = locationModelValidator;
			this.BolLocationMapper = bolLocationMapper;
			this.DalLocationMapper = dalLocationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLocationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LocationRepository.All(limit, offset);

			return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationServerResponseModel> Get(short locationID)
		{
			var record = await this.LocationRepository.Get(locationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLocationServerResponseModel>> Create(
			ApiLocationServerRequestModel model)
		{
			CreateResponse<ApiLocationServerResponseModel> response = ValidationResponseFactory<ApiLocationServerResponseModel>.CreateResponse(await this.LocationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLocationMapper.MapModelToBO(default(short), model);
				var record = await this.LocationRepository.Create(this.DalLocationMapper.MapBOToEF(bo));

				var businessObject = this.DalLocationMapper.MapEFToBO(record);
				response.SetRecord(this.BolLocationMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new LocationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationServerResponseModel>> Update(
			short locationID,
			ApiLocationServerRequestModel model)
		{
			var validationResult = await this.LocationModelValidator.ValidateUpdateAsync(locationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLocationMapper.MapModelToBO(locationID, model);
				await this.LocationRepository.Update(this.DalLocationMapper.MapBOToEF(bo));

				var record = await this.LocationRepository.Get(locationID);

				var businessObject = this.DalLocationMapper.MapEFToBO(record);
				var apiModel = this.BolLocationMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new LocationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLocationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLocationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LocationModelValidator.ValidateDeleteAsync(locationID));

			if (response.Success)
			{
				await this.LocationRepository.Delete(locationID);

				await this.mediator.Publish(new LocationDeletedNotification(locationID));
			}

			return response;
		}

		public async virtual Task<ApiLocationServerResponseModel> ByName(string name)
		{
			Location record = await this.LocationRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>baa92fa81c26b27d8538ec357e630902</Hash>
</Codenesium>*/