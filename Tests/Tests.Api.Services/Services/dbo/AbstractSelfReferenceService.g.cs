using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSelfReferenceService : AbstractService
	{
		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		protected IApiSelfReferenceServerRequestModelValidator SelfReferenceModelValidator { get; private set; }

		protected IBOLSelfReferenceMapper BolSelfReferenceMapper { get; private set; }

		protected IDALSelfReferenceMapper DalSelfReferenceMapper { get; private set; }

		private ILogger logger;

		public AbstractSelfReferenceService(
			ILogger logger,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceServerRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base()
		{
			this.SelfReferenceRepository = selfReferenceRepository;
			this.SelfReferenceModelValidator = selfReferenceModelValidator;
			this.BolSelfReferenceMapper = bolSelfReferenceMapper;
			this.DalSelfReferenceMapper = dalSelfReferenceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSelfReferenceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SelfReferenceRepository.All(limit, offset);

			return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSelfReferenceServerResponseModel> Get(int id)
		{
			var record = await this.SelfReferenceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceServerResponseModel>> Create(
			ApiSelfReferenceServerRequestModel model)
		{
			CreateResponse<ApiSelfReferenceServerResponseModel> response = ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.CreateResponse(await this.SelfReferenceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSelfReferenceMapper.MapModelToBO(default(int), model);
				var record = await this.SelfReferenceRepository.Create(this.DalSelfReferenceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSelfReferenceServerResponseModel>> Update(
			int id,
			ApiSelfReferenceServerRequestModel model)
		{
			var validationResult = await this.SelfReferenceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSelfReferenceMapper.MapModelToBO(id, model);
				await this.SelfReferenceRepository.Update(this.DalSelfReferenceMapper.MapBOToEF(bo));

				var record = await this.SelfReferenceRepository.Get(id);

				return ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.UpdateResponse(this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSelfReferenceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SelfReferenceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SelfReferenceRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dfa3b586b2542298c3179794af0bba56</Hash>
</Codenesium>*/