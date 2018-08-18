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
	public abstract class AbstractPersonRefService : AbstractService
	{
		protected IPersonRefRepository PersonRefRepository { get; private set; }

		protected IApiPersonRefRequestModelValidator PersonRefModelValidator { get; private set; }

		protected IBOLPersonRefMapper BolPersonRefMapper { get; private set; }

		protected IDALPersonRefMapper DalPersonRefMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonRefService(
			ILogger logger,
			IPersonRefRepository personRefRepository,
			IApiPersonRefRequestModelValidator personRefModelValidator,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper)
			: base()
		{
			this.PersonRefRepository = personRefRepository;
			this.PersonRefModelValidator = personRefModelValidator;
			this.BolPersonRefMapper = bolPersonRefMapper;
			this.DalPersonRefMapper = dalPersonRefMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonRefResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRefRepository.All(limit, offset);

			return this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonRefResponseModel> Get(int id)
		{
			var record = await this.PersonRefRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonRefResponseModel>> Create(
			ApiPersonRefRequestModel model)
		{
			CreateResponse<ApiPersonRefResponseModel> response = new CreateResponse<ApiPersonRefResponseModel>(await this.PersonRefModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPersonRefMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRefRepository.Create(this.DalPersonRefMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonRefResponseModel>> Update(
			int id,
			ApiPersonRefRequestModel model)
		{
			var validationResult = await this.PersonRefModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonRefMapper.MapModelToBO(id, model);
				await this.PersonRefRepository.Update(this.DalPersonRefMapper.MapBOToEF(bo));

				var record = await this.PersonRefRepository.Get(id);

				return new UpdateResponse<ApiPersonRefResponseModel>(this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonRefResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PersonRefModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PersonRefRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3ccec1fc1ad33b08b656c35f271a81c0</Hash>
</Codenesium>*/