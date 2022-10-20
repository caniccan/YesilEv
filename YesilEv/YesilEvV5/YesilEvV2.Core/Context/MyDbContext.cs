using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.Core.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext():base("name=CanConn")
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=YesilEvDbV2;Integrated Security=True");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // ilişkileri kurarken Fluent API ve Data Annotation yerine Default Convention tercih ettim.
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                // Bu bölümlere,
                // SaveChanges() methodu her kullanıldığında Db'ye gitmeden önce yapılacak işlemler girilecek.
                if (entry.State==EntityState.Added)
                {
                    // Insert işlemlerinde
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Update işlemlerinde
                }
                else if (entry.State==EntityState.Deleted)
                {
                    // Delete işlemlerinde
                }
                else 
                {
                    // Diğer EntityState durumları "else if" şeklinde eklenebilir.
                }

            }
            return base.SaveChanges();
        }




        public DbSet<Arama> aramaGecmisi { get; set; }
        public DbSet<Kategori> kategori { get; set; }
        public DbSet<Urun> urun { get; set; }
        public DbSet<Duzenleme> duzenleme { get; set; }
        public DbSet<Favori> favoriler { get; set; }
        public DbSet<FavoriListe> favoriListe { get; set; }
        public DbSet<KaraListe> karaListe { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<RolYetki> rolYetki { get; set; }
        public DbSet<Uretici> uretici { get; set; }
        public DbSet<Uye> uye { get; set; }
        public DbSet<Bildirim> bildirim { get; set; }
        public DbSet<UrunIcerik> UrunIcerik { get; set; }
        public DbSet<AlerjikMadde> AlerjikMadde { get; set; }
        public DbSet<Hasta> Hasta { get; set; }
        public DbSet<Puan> Puan { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<YorumOnay> YorumOnay { get; set; }


    }
}
