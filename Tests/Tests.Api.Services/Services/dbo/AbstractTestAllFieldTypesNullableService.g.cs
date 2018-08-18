using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTestAllFieldTypesNullableService : AbstractService
	{
		protected ITestAllFieldTypesNullableRepository TestAllFieldTypesNullableRepository { get; private set; }

		protected IApiTestAllFieldTypesNullableRequestModelValidator TestAllFieldTypesNullableModelValidator { get; private set; }

		protected IBOLTestAllFieldTypesNullableMapper BolTestAllFieldTypesNullableMapper { get; private set; }

		protected IDALTestAllFieldTypesNullableMapper DalTestAllFieldTypesNullableMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypesNullableService(
			ILogger logger,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableRequestModelValidator testAllFieldTypesNullableModelValidator,
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

		public virtual async Task<List<ApiTestAllFieldTypesNullableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TestAllFieldTypesNullableRepository.All(limit, offset);

			return this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTestAllFieldTypesNullableResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>> Create(
			ApiTestAllFieldTypesNullableRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypesNullableResponseModel> response = new CreateResponse<ApiTestAllFieldTypesNullableResponseModel>(await this.TestAllFieldTypesNullableModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTestAllFieldTypesNullableMapper.MapModelToBO(default(int), model);
				var record = await this.TestAllFieldTypesNullableRepository.Create(this.DalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>> Update(
			int id,
			ApiTestAllFieldTypesNullableRequestModel model)
		{
			var validationResult = await this.TestAllFieldTypesNullableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTestAllFieldTypesNullableMapper.MapModelToBO(id, model);
				await this.TestAllFieldTypesNullableRepository.Update(this.DalTestAllFieldTypesNullableMapper.MapBOToEF(bo));

				var record = await this.TestAllFieldTypesNullableRepository.Get(id);

				return new UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>(this.BolTestAllFieldTypesNullableMapper.MapBOToModel(this.DalTestAllFieldTypesNullableMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TestAllFieldTypesNullableModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TestAllFieldTypesNullableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>813de822eb8e3a0ee9da36a53c4ae734</Hash>
</Codenesium>*/