using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTableService : AbstractService
	{
		protected ITableRepository TableRepository { get; private set; }

		protected IApiTableServerRequestModelValidator TableModelValidator { get; private set; }

		protected IBOLTableMapper BolTableMapper { get; private set; }

		protected IDALTableMapper DalTableMapper { get; private set; }

		private ILogger logger;

		public AbstractTableService(
			ILogger logger,
			ITableRepository tableRepository,
			IApiTableServerRequestModelValidator tableModelValidator,
			IBOLTableMapper bolTableMapper,
			IDALTableMapper dalTableMapper)
			: base()
		{
			this.TableRepository = tableRepository;
			this.TableModelValidator = tableModelValidator;
			this.BolTableMapper = bolTableMapper;
			this.DalTableMapper = dalTableMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TableRepository.All(limit, offset);

			return this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTableServerResponseModel> Get(int id)
		{
			var record = await this.TableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTableServerResponseModel>> Create(
			ApiTableServerRequestModel model)
		{
			CreateResponse<ApiTableServerResponseModel> response = ValidationResponseFactory<ApiTableServerResponseModel>.CreateResponse(await this.TableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTableMapper.MapModelToBO(default(int), model);
				var record = await this.TableRepository.Create(this.DalTableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTableServerResponseModel>> Update(
			int id,
			ApiTableServerRequestModel model)
		{
			var validationResult = await this.TableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTableMapper.MapModelToBO(id, model);
				await this.TableRepository.Update(this.DalTableMapper.MapBOToEF(bo));

				var record = await this.TableRepository.Get(id);

				return ValidationResponseFactory<ApiTableServerResponseModel>.UpdateResponse(this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTableServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TableModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>583bfa81e46ddd67e35ba0ef3a6f204b</Hash>
</Codenesium>*/