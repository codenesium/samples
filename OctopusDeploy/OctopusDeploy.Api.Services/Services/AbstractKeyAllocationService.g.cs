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
	public abstract class AbstractKeyAllocationService : AbstractService
	{
		protected IKeyAllocationRepository KeyAllocationRepository { get; private set; }

		protected IApiKeyAllocationRequestModelValidator KeyAllocationModelValidator { get; private set; }

		protected IBOLKeyAllocationMapper BolKeyAllocationMapper { get; private set; }

		protected IDALKeyAllocationMapper DalKeyAllocationMapper { get; private set; }

		private ILogger logger;

		public AbstractKeyAllocationService(
			ILogger logger,
			IKeyAllocationRepository keyAllocationRepository,
			IApiKeyAllocationRequestModelValidator keyAllocationModelValidator,
			IBOLKeyAllocationMapper bolKeyAllocationMapper,
			IDALKeyAllocationMapper dalKeyAllocationMapper)
			: base()
		{
			this.KeyAllocationRepository = keyAllocationRepository;
			this.KeyAllocationModelValidator = keyAllocationModelValidator;
			this.BolKeyAllocationMapper = bolKeyAllocationMapper;
			this.DalKeyAllocationMapper = dalKeyAllocationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiKeyAllocationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.KeyAllocationRepository.All(limit, offset);

			return this.BolKeyAllocationMapper.MapBOToModel(this.DalKeyAllocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiKeyAllocationResponseModel> Get(string collectionName)
		{
			var record = await this.KeyAllocationRepository.Get(collectionName);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolKeyAllocationMapper.MapBOToModel(this.DalKeyAllocationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiKeyAllocationResponseModel>> Create(
			ApiKeyAllocationRequestModel model)
		{
			CreateResponse<ApiKeyAllocationResponseModel> response = new CreateResponse<ApiKeyAllocationResponseModel>(await this.KeyAllocationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolKeyAllocationMapper.MapModelToBO(default(string), model);
				var record = await this.KeyAllocationRepository.Create(this.DalKeyAllocationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolKeyAllocationMapper.MapBOToModel(this.DalKeyAllocationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiKeyAllocationResponseModel>> Update(
			string collectionName,
			ApiKeyAllocationRequestModel model)
		{
			var validationResult = await this.KeyAllocationModelValidator.ValidateUpdateAsync(collectionName, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolKeyAllocationMapper.MapModelToBO(collectionName, model);
				await this.KeyAllocationRepository.Update(this.DalKeyAllocationMapper.MapBOToEF(bo));

				var record = await this.KeyAllocationRepository.Get(collectionName);

				return new UpdateResponse<ApiKeyAllocationResponseModel>(this.BolKeyAllocationMapper.MapBOToModel(this.DalKeyAllocationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiKeyAllocationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string collectionName)
		{
			ActionResponse response = new ActionResponse(await this.KeyAllocationModelValidator.ValidateDeleteAsync(collectionName));
			if (response.Success)
			{
				await this.KeyAllocationRepository.Delete(collectionName);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>31997572eb96d10ac0a6b6f09ad1b640</Hash>
</Codenesium>*/