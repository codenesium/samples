using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractExtensionConfigurationService : AbstractService
	{
		protected IExtensionConfigurationRepository ExtensionConfigurationRepository { get; private set; }

		protected IApiExtensionConfigurationRequestModelValidator ExtensionConfigurationModelValidator { get; private set; }

		protected IBOLExtensionConfigurationMapper BolExtensionConfigurationMapper { get; private set; }

		protected IDALExtensionConfigurationMapper DalExtensionConfigurationMapper { get; private set; }

		private ILogger logger;

		public AbstractExtensionConfigurationService(
			ILogger logger,
			IExtensionConfigurationRepository extensionConfigurationRepository,
			IApiExtensionConfigurationRequestModelValidator extensionConfigurationModelValidator,
			IBOLExtensionConfigurationMapper bolExtensionConfigurationMapper,
			IDALExtensionConfigurationMapper dalExtensionConfigurationMapper)
			: base()
		{
			this.ExtensionConfigurationRepository = extensionConfigurationRepository;
			this.ExtensionConfigurationModelValidator = extensionConfigurationModelValidator;
			this.BolExtensionConfigurationMapper = bolExtensionConfigurationMapper;
			this.DalExtensionConfigurationMapper = dalExtensionConfigurationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiExtensionConfigurationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ExtensionConfigurationRepository.All(limit, offset);

			return this.BolExtensionConfigurationMapper.MapBOToModel(this.DalExtensionConfigurationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiExtensionConfigurationResponseModel> Get(string id)
		{
			var record = await this.ExtensionConfigurationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolExtensionConfigurationMapper.MapBOToModel(this.DalExtensionConfigurationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiExtensionConfigurationResponseModel>> Create(
			ApiExtensionConfigurationRequestModel model)
		{
			CreateResponse<ApiExtensionConfigurationResponseModel> response = new CreateResponse<ApiExtensionConfigurationResponseModel>(await this.ExtensionConfigurationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolExtensionConfigurationMapper.MapModelToBO(default(string), model);
				var record = await this.ExtensionConfigurationRepository.Create(this.DalExtensionConfigurationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolExtensionConfigurationMapper.MapBOToModel(this.DalExtensionConfigurationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiExtensionConfigurationResponseModel>> Update(
			string id,
			ApiExtensionConfigurationRequestModel model)
		{
			var validationResult = await this.ExtensionConfigurationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolExtensionConfigurationMapper.MapModelToBO(id, model);
				await this.ExtensionConfigurationRepository.Update(this.DalExtensionConfigurationMapper.MapBOToEF(bo));

				var record = await this.ExtensionConfigurationRepository.Get(id);

				return new UpdateResponse<ApiExtensionConfigurationResponseModel>(this.BolExtensionConfigurationMapper.MapBOToModel(this.DalExtensionConfigurationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiExtensionConfigurationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ExtensionConfigurationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ExtensionConfigurationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>05c4eb6a70e34e646da51ee9f862cc51</Hash>
</Codenesium>*/