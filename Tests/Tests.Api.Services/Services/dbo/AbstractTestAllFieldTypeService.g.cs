using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTestAllFieldTypeService : AbstractService
	{
		protected ITestAllFieldTypeRepository TestAllFieldTypeRepository { get; private set; }

		protected IApiTestAllFieldTypeServerRequestModelValidator TestAllFieldTypeModelValidator { get; private set; }

		protected IBOLTestAllFieldTypeMapper BolTestAllFieldTypeMapper { get; private set; }

		protected IDALTestAllFieldTypeMapper DalTestAllFieldTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypeService(
			ILogger logger,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeServerRequestModelValidator testAllFieldTypeModelValidator,
			IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base()
		{
			this.TestAllFieldTypeRepository = testAllFieldTypeRepository;
			this.TestAllFieldTypeModelValidator = testAllFieldTypeModelValidator;
			this.BolTestAllFieldTypeMapper = bolTestAllFieldTypeMapper;
			this.DalTestAllFieldTypeMapper = dalTestAllFieldTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTestAllFieldTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TestAllFieldTypeRepository.All(limit, offset);

			return this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTestAllFieldTypeServerResponseModel> Get(int id)
		{
			var record = await this.TestAllFieldTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypeServerResponseModel>> Create(
			ApiTestAllFieldTypeServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.CreateResponse(await this.TestAllFieldTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTestAllFieldTypeMapper.MapModelToBO(default(int), model);
				var record = await this.TestAllFieldTypeRepository.Create(this.DalTestAllFieldTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>> Update(
			int id,
			ApiTestAllFieldTypeServerRequestModel model)
		{
			var validationResult = await this.TestAllFieldTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTestAllFieldTypeMapper.MapModelToBO(id, model);
				await this.TestAllFieldTypeRepository.Update(this.DalTestAllFieldTypeMapper.MapBOToEF(bo));

				var record = await this.TestAllFieldTypeRepository.Get(id);

				return ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.UpdateResponse(this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TestAllFieldTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TestAllFieldTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c6fffe7896606f8ded72d932246bebd3</Hash>
</Codenesium>*/