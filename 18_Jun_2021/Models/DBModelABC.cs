using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace _18_Jun_2021.Models
{
    public partial class DBModelABC : DbContext
    {
        public DBModelABC()
            : base("name=DBModelABC")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Station> Stations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
