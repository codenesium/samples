using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Store", Schema="Sales")]
        public partial class Store : AbstractEntity
        {
                public Store()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        string demographics,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        Nullable<int> salesPersonID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("Demographics")]
                public string Demographics { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesPersonID")]
                public Nullable<int> SalesPersonID { get; private set; }

                [ForeignKey("SalesPersonID")]
                public virtual SalesPerson SalesPerson { get; set; }
        }
}

/*<Codenesium>
    <Hash>19323c0c9cd5fde17a40fb8ef99e5c53</Hash>
</Codenesium>*/