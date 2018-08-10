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
		protected ITableRepository TableRepository { get; private set; }

		protected IApiTableRequestModelValidator TableModelValidator { get; private set; }

		protected IBOLTableMapper BolTableMapper { get; private set; }

		protected IDALTableMapper DalTableMapper { get; private set; }

		private ILogger logger;

		public AbstractTableService(
			ILogger logger,
			ITableRepository tableRepository,
			IApiTableRequestModelValidator tableModelValidator,
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

		public virtual async Task<List<ApiTableResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TableRepository.All(limit, offset);

			return this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTableResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiTableResponseModel>> Create(
			ApiTableRequestModel model)
		{
			CreateResponse<ApiTableResponseModel> response = new CreateResponse<ApiTableResponseModel>(await this.TableModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTableMapper.MapModelToBO(default(int), model);
				var record = await this.TableRepository.Create(this.DalTableMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTableResponseModel>> Update(
			int id,
			ApiTableRequestModel model)
		{
			var validationResult = await this.TableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTableMapper.MapModelToBO(id, model);
				await this.TableRepository.Update(this.DalTableMapper.MapBOToEF(bo));

				var record = await this.TableRepository.Get(id);

				return new UpdateResponse<ApiTableResponseModel>(this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTableResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TableModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TableRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8cea415f8092570d73728291fa5285a6</Hash>
</Codenesium>*/