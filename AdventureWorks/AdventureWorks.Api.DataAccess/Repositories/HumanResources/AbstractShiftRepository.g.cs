using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShiftRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALShiftMapper Mapper { get; }

		public AbstractShiftRepository(
			IDALShiftMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOShift> Get(int shiftID)
		{
			Shift record = await this.GetById(shiftID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOShift> Create(
			DTOShift dto)
		{
			Shift record = new Shift();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Shift>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int shiftID,
			DTOShift dto)
		{
			Shift record = await this.GetById(shiftID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shiftID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					shiftID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int shiftID)
		{
			Shift record = await this.GetById(shiftID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Shift>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOShift> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<DTOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			var records = await this.SearchLinqDTO(x => x.StartTime == startTime && x.EndTime == endTime);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOShift>> Where(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShift> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOShift>> SearchLinqDTO(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShift> response = new List<DTOShift>();
			List<Shift> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Shift>> SearchLinqEF(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}
			return await this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Shift>();
		}

		private async Task<List<Shift>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}

			return await this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Shift>();
		}

		private async Task<Shift> GetById(int shiftID)
		{
			List<Shift> records = await this.SearchLinqEF(x => x.ShiftID == shiftID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4fa3a390f041ea02860e6a3d2f8a2567</Hash>
</Codenesium>*/