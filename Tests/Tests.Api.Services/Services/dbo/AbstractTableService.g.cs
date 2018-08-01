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
	public abstract class AbstractTableService : AbstractService
	{
		private ITableRepository tableRepository;

		private IApiTableRequestModelValidator tableModelValidator;

		private IBOLTableMapper bolTableMapper;

		private IDALTableMapper dalTableMapper;

		private ILogger logger;

		public AbstractTableService(
			ILogger logger,
			ITableRepository tableRepository,
			IApiTableRequestModelValidator tableModelValidator,
			IBOLTableMapper bolTableMapper,
			IDALTableMapper dalTableMapper)
			: base()
		{
			this.tableRepository = tableRepository;
			this.tableModelValidator = tableModelValidator;
			this.bolTableMapper = bolTableMapper;
			this.dalTableMapper = dalTableMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.tableRepository.All(limit, offset);

			return this.bolTableMapper.MapBOToModel(this.dalTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTableResponseModel> Get(int id)
		{
			var record = await this.tableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTableMapper.MapBOToModel(this.dalTableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTableResponseModel>> Create(
			ApiTableRequestModel model)
		{
			CreateResponse<ApiTableResponseModel> response = new CreateResponse<ApiTableResponseModel>(await this.tableModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTableMapper.MapModelToBO(default(int), model);
				var record = await this.tableRepository.Create(this.dalTableMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTableMapper.MapBOToModel(this.dalTableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTableResponseModel>> Update(
			int id,
			ApiTableRequestModel model)
		{
			var validationResult = await this.tableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTableMapper.MapModelToBO(id, model);
				await this.tableRepository.Update(this.dalTableMapper.MapBOToEF(bo));

				var record = await this.tableRepository.Get(id);

				return new UpdateResponse<ApiTableResponseModel>(this.bolTableMapper.MapBOToModel(this.dalTableMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTableResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.tableModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.tableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>97179fd69cb1029e37819c0d6d5c554b</Hash>
</Codenesium>*/