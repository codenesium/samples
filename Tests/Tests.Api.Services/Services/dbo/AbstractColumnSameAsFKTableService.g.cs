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
	public abstract class AbstractColumnSameAsFKTableService : AbstractService
	{
		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		protected IApiColumnSameAsFKTableRequestModelValidator ColumnSameAsFKTableModelValidator { get; private set; }

		protected IBOLColumnSameAsFKTableMapper BolColumnSameAsFKTableMapper { get; private set; }

		protected IDALColumnSameAsFKTableMapper DalColumnSameAsFKTableMapper { get; private set; }

		private ILogger logger;

		public AbstractColumnSameAsFKTableService(
			ILogger logger,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableRequestModelValidator columnSameAsFKTableModelValidator,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base()
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
			this.ColumnSameAsFKTableModelValidator = columnSameAsFKTableModelValidator;
			this.BolColumnSameAsFKTableMapper = bolColumnSameAsFKTableMapper;
			this.DalColumnSameAsFKTableMapper = dalColumnSameAsFKTableMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiColumnSameAsFKTableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ColumnSameAsFKTableRepository.All(limit, offset);

			return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiColumnSameAsFKTableResponseModel> Get(int id)
		{
			var record = await this.ColumnSameAsFKTableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiColumnSameAsFKTableResponseModel>> Create(
			ApiColumnSameAsFKTableRequestModel model)
		{
			CreateResponse<ApiColumnSameAsFKTableResponseModel> response = new CreateResponse<ApiColumnSameAsFKTableResponseModel>(await this.ColumnSameAsFKTableModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolColumnSameAsFKTableMapper.MapModelToBO(default(int), model);
				var record = await this.ColumnSameAsFKTableRepository.Create(this.DalColumnSameAsFKTableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiColumnSameAsFKTableResponseModel>> Update(
			int id,
			ApiColumnSameAsFKTableRequestModel model)
		{
			var validationResult = await this.ColumnSameAsFKTableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolColumnSameAsFKTableMapper.MapModelToBO(id, model);
				await this.ColumnSameAsFKTableRepository.Update(this.DalColumnSameAsFKTableMapper.MapBOToEF(bo));

				var record = await this.ColumnSameAsFKTableRepository.Get(id);

				return new UpdateResponse<ApiColumnSameAsFKTableResponseModel>(this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiColumnSameAsFKTableResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ColumnSameAsFKTableModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ColumnSameAsFKTableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4ff167a81396765d4b94470a6ba63016</Hash>
</Codenesium>*/