using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractTeacherXTeacherSkillRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALTeacherXTeacherSkillMapper Mapper { get; }

		public AbstractTeacherXTeacherSkillRepository(
			IDALTeacherXTeacherSkillMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOTeacherXTeacherSkill> Get(int id)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOTeacherXTeacherSkill> Create(
			DTOTeacherXTeacherSkill dto)
		{
			TeacherXTeacherSkill record = new TeacherXTeacherSkill();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<TeacherXTeacherSkill>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int id,
			DTOTeacherXTeacherSkill dto)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					id,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherXTeacherSkill>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOTeacherXTeacherSkill>> Where(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTeacherXTeacherSkill> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOTeacherXTeacherSkill>> SearchLinqDTO(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOTeacherXTeacherSkill> response = new List<DTOTeacherXTeacherSkill>();
			List<TeacherXTeacherSkill> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<TeacherXTeacherSkill>> SearchLinqEF(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}
			return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherXTeacherSkill>();
		}

		private async Task<List<TeacherXTeacherSkill>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}

			return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherXTeacherSkill>();
		}

		private async Task<TeacherXTeacherSkill> GetById(int id)
		{
			List<TeacherXTeacherSkill> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6a68c191f1b62c4c2011e1e5f377ea99</Hash>
</Codenesium>*/