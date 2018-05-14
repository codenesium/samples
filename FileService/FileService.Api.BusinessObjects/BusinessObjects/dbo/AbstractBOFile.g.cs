using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOFile
	{
		private IFileRepository fileRepository;
		private IFileModelValidator fileModelValidator;
		private ILogger logger;

		public AbstractBOFile(
			ILogger logger,
			IFileRepository fileRepository,
			IFileModelValidator fileModelValidator)

		{
			this.fileRepository = fileRepository;
			this.fileModelValidator = fileModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.fileRepository.All(skip, take, orderClause);
		}

		public virtual POCOFile Get(int id)
		{
			return this.fileRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOFile>> Create(
			FileModel model)
		{
			CreateResponse<POCOFile> response = new CreateResponse<POCOFile>(await this.fileModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOFile record = this.fileRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			FileModel model)
		{
			ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.fileRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.fileRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>86177efb99b3b1453ecdae0c4c2bc4b4</Hash>
</Codenesium>*/