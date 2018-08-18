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
	public abstract class AbstractApiKeyService : AbstractService
	{
		protected IApiKeyRepository ApiKeyRepository { get; private set; }

		protected IApiApiKeyRequestModelValidator ApiKeyModelValidator { get; private set; }

		protected IBOLApiKeyMapper BolApiKeyMapper { get; private set; }

		protected IDALApiKeyMapper DalApiKeyMapper { get; private set; }

		private ILogger logger;

		public AbstractApiKeyService(
			ILogger logger,
			IApiKeyRepository apiKeyRepository,
			IApiApiKeyRequestModelValidator apiKeyModelValidator,
			IBOLApiKeyMapper bolApiKeyMapper,
			IDALApiKeyMapper dalApiKeyMapper)
			: base()
		{
			this.ApiKeyRepository = apiKeyRepository;
			this.ApiKeyModelValidator = apiKeyModelValidator;
			this.BolApiKeyMapper = bolApiKeyMapper;
			this.DalApiKeyMapper = dalApiKeyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiApiKeyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ApiKeyRepository.All(limit, offset);

			return this.BolApiKeyMapper.MapBOToModel(this.DalApiKeyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiApiKeyResponseModel> Get(string id)
		{
			var record = await this.ApiKeyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolApiKeyMapper.MapBOToModel(this.DalApiKeyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiApiKeyResponseModel>> Create(
			ApiApiKeyRequestModel model)
		{
			CreateResponse<ApiApiKeyResponseModel> response = new CreateResponse<ApiApiKeyResponseModel>(await this.ApiKeyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolApiKeyMapper.MapModelToBO(default(string), model);
				var record = await this.ApiKeyRepository.Create(this.DalApiKeyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolApiKeyMapper.MapBOToModel(this.DalApiKeyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiApiKeyResponseModel>> Update(
			string id,
			ApiApiKeyRequestModel model)
		{
			var validationResult = await this.ApiKeyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolApiKeyMapper.MapModelToBO(id, model);
				await this.ApiKeyRepository.Update(this.DalApiKeyMapper.MapBOToEF(bo));

				var record = await this.ApiKeyRepository.Get(id);

				return new UpdateResponse<ApiApiKeyResponseModel>(this.BolApiKeyMapper.MapBOToModel(this.DalApiKeyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiApiKeyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ApiKeyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ApiKeyRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiApiKeyResponseModel> ByApiKeyHashed(string apiKeyHashed)
		{
			ApiKey record = await this.ApiKeyRepository.ByApiKeyHashed(apiKeyHashed);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolApiKeyMapper.MapBOToModel(this.DalApiKeyMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>421f6d192290097ad4c76fb1efa6894a</Hash>
</Codenesium>*/