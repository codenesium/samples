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
	public abstract class AbstractShipMethodRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALShipMethodMapper Mapper { get; }

		public AbstractShipMethodRepository(
			IDALShipMethodMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOShipMethod> Get(int shipMethodID)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOShipMethod> Create(
			DTOShipMethod dto)
		{
			ShipMethod record = new ShipMethod();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ShipMethod>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int shipMethodID,
			DTOShipMethod dto)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shipMethodID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					shipMethodID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int shipMethodID)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShipMethod>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOShipMethod> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOShipMethod>> Where(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShipMethod> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOShipMethod>> SearchLinqDTO(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShipMethod> response = new List<DTOShipMethod>();
			List<ShipMethod> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ShipMethod>> SearchLinqEF(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}
			return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShipMethod>();
		}

		private async Task<List<ShipMethod>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}

			return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShipMethod>();
		}

		private async Task<ShipMethod> GetById(int shipMethodID)
		{
			List<ShipMethod> records = await this.SearchLinqEF(x => x.ShipMethodID == shipMethodID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>603a025cbdc3dc0ae6df3be10c60e5bb</Hash>
</Codenesium>*/