using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTestAllFieldTypesNullableService : AbstractService
	{
		protected ITestAllFieldTypesNullableRepository TestAllFieldTypesNullableRepository { get; private set; }

		protected IApiTestAllFieldTypesNullableServerRequestModelValidator TestAllFieldTypesNullableModelValidator { get; private set; }

		protected IBOLTestAllFieldTypesNullableMapper BolTestAllFieldTypesNullableMapper { get; private set; }

		protected IDALTestAllFieldTypesNullableMapper DalTestAllFieldTypesNullableMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypesNullableService(
			ILogger logger,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableServerRequestModelValidator testAllFieldTypesNullableModelValidator,
			IBOLTestAllFieldTypesNullableMapper bolTestAllFieldTypesNullableMapper,
			IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
			: base()
		{
			this.TestAllFieldTypesNullableRepository = testAllFieldTypesNullableRepository;
			this.TestAllFieldTypesNullableModelValidator = testAllFieldTypesNullableModelValidator;
			this.BolTestAllFieldTypesNullableMapper = bolTestAllFieldTypesNullableMapper;
			this.DalTestAllFieldTypesNullableMapper = dalTestAllFieldTypesNullableMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTestAllFieldTypesNullableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TestAllFieldTypesNullableRepository.All(limit, offset);

			return this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTestAllFieldTypesNullableServerResponseModel> Get(int id)
		{
			var record = await this.TestAllFieldTypesNullableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Create(
			ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.CreateResponse(await this.TestAllFieldTypesNullableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTestAllFieldTypesNullableMapper.MapModelToBO(default(int), model);
				var record = await this.TestAllFieldTypesNullableRepository.Create(this.DalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Update(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			var validationResult = await this.TestAllFieldTypesNullableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTestAllFieldTypesNullableMapper.MapModelToBO(id, model);
				await this.TestAllFieldTypesNullableRepository.Update(this.DalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

				var record = await this.TestAllFieldTypesNullableRepository.Get(id);

				return ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.UpdateResponse(this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TestAllFieldTypesNullableModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TestAllFieldTypesNullableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>18a5c152bb20f0996c8668c244076292</Hash>
</Codenesium>*/