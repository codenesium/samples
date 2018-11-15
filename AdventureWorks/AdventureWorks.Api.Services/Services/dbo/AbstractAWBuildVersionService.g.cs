using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAWBuildVersionService : AbstractService
	{
		protected IAWBuildVersionRepository AWBuildVersionRepository { get; private set; }

		protected IApiAWBuildVersionServerRequestModelValidator AWBuildVersionModelValidator { get; private set; }

		protected IBOLAWBuildVersionMapper BolAWBuildVersionMapper { get; private set; }

		protected IDALAWBuildVersionMapper DalAWBuildVersionMapper { get; private set; }

		private ILogger logger;

		public AbstractAWBuildVersionService(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionServerRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper bolAWBuildVersionMapper,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base()
		{
			this.AWBuildVersionRepository = aWBuildVersionRepository;
			this.AWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.BolAWBuildVersionMapper = bolAWBuildVersionMapper;
			this.DalAWBuildVersionMapper = dalAWBuildVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAWBuildVersionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AWBuildVersionRepository.All(limit, offset);

			return this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAWBuildVersionServerResponseModel> Get(int systemInformationID)
		{
			var record = await this.AWBuildVersionRepository.Get(systemInformationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionServerResponseModel>> Create(
			ApiAWBuildVersionServerRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionServerResponseModel> response = ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.CreateResponse(await this.AWBuildVersionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAWBuildVersionMapper.MapModelToBO(default(int), model);
				var record = await this.AWBuildVersionRepository.Create(this.DalAWBuildVersionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAWBuildVersionServerResponseModel>> Update(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model)
		{
			var validationResult = await this.AWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAWBuildVersionMapper.MapModelToBO(systemInformationID, model);
				await this.AWBuildVersionRepository.Update(this.DalAWBuildVersionMapper.MapBOToEF(bo));

				var record = await this.AWBuildVersionRepository.Get(systemInformationID);

				return ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.UpdateResponse(this.BolAWBuildVersionMapper.MapBOToModel(this.DalAWBuildVersionMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));

			if (response.Success)
			{
				await this.AWBuildVersionRepository.Delete(systemInformationID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>809895f92eed1dd0b43255f73e829ac2</Hash>
</Codenesium>*/