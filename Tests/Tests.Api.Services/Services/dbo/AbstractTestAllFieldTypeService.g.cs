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
	public abstract class AbstractTestAllFieldTypeService : AbstractService
	{
		private ITestAllFieldTypeRepository testAllFieldTypeRepository;

		private IApiTestAllFieldTypeRequestModelValidator testAllFieldTypeModelValidator;

		private IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper;

		private IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper;

		private ILogger logger;

		public AbstractTestAllFieldTypeService(
			ILogger logger,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeRequestModelValidator testAllFieldTypeModelValidator,
			IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base()
		{
			this.testAllFieldTypeRepository = testAllFieldTypeRepository;
			this.testAllFieldTypeModelValidator = testAllFieldTypeModelValidator;
			this.bolTestAllFieldTypeMapper = bolTestAllFieldTypeMapper;
			this.dalTestAllFieldTypeMapper = dalTestAllFieldTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTestAllFieldTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.testAllFieldTypeRepository.All(limit, offset);

			return this.bolTestAllFieldTypeMapper.MapBOToModel(this.dalTestAllFieldTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTestAllFieldTypeResponseModel> Get(int id)
		{
			var record = await this.testAllFieldTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTestAllFieldTypeMapper.MapBOToModel(this.dalTestAllFieldTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypeResponseModel>> Create(
			ApiTestAllFieldTypeRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypeResponseModel> response = new CreateResponse<ApiTestAllFieldTypeResponseModel>(await this.testAllFieldTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTestAllFieldTypeMapper.MapModelToBO(default(int), model);
				var record = await this.testAllFieldTypeRepository.Create(this.dalTestAllFieldTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTestAllFieldTypeMapper.MapBOToModel(this.dalTestAllFieldTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypeResponseModel>> Update(
			int id,
			ApiTestAllFieldTypeRequestModel model)
		{
			var validationResult = await this.testAllFieldTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTestAllFieldTypeMapper.MapModelToBO(id, model);
				await this.testAllFieldTypeRepository.Update(this.dalTestAllFieldTypeMapper.MapBOToEF(bo));

				var record = await this.testAllFieldTypeRepository.Get(id);

				return new UpdateResponse<ApiTestAllFieldTypeResponseModel>(this.bolTestAllFieldTypeMapper.MapBOToModel(this.dalTestAllFieldTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTestAllFieldTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.testAllFieldTypeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.testAllFieldTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4bff381d8b0d61506d515acb3b44e3c7</Hash>
</Codenesium>*/