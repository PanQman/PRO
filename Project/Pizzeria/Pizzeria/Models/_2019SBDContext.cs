using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class _2019SBDContext : DbContext
    {
        public _2019SBDContext()
        {
        }

        public _2019SBDContext(DbContextOptions<_2019SBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<Dostawa> Dostawa { get; set; }
        public virtual DbSet<Dydaktyk> Dydaktyk { get; set; }
        public virtual DbSet<Grupa> Grupa { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Ocena> Ocena { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<Panstwo> Panstwo { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Platnosc> Platnosc { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Przedmiot> Przedmiot { get; set; }
        public virtual DbSet<PrzedmiotPoprzedzajacy> PrzedmiotPoprzedzajacy { get; set; }
        public virtual DbSet<RokAkademicki> RokAkademicki { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<StopnieTytuly> StopnieTytuly { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentGrupa> StudentGrupa { get; set; }
        public virtual DbSet<Uprawnienia> Uprawnienia { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "s15269");

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.ToTable("dodatek");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaDodatku)
                    .IsRequired()
                    .HasColumnName("nazwa_dodatku")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawa>(entity =>
            {
                entity.ToTable("dostawa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenaDostawy)
                    .HasColumnName("cena_dostawy")
                    .HasColumnType("money");

                entity.Property(e => e.CzasDostawy)
                    .HasColumnName("czas_dostawy")
                    .HasColumnType("date");

                entity.Property(e => e.MiejsceDostawcy)
                    .IsRequired()
                    .HasColumnName("miejsce_dostawcy")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dydaktyk>(entity =>
            {
                entity.HasKey(e => e.IdOsoba);

                entity.Property(e => e.IdOsoba).ValueGeneratedNever();

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Dydaktyk)
                    .HasForeignKey<Dydaktyk>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Dydaktyk_FK1");

                entity.HasOne(d => d.IdStopienNavigation)
                    .WithMany(p => p.Dydaktyk)
                    .HasForeignKey(d => d.IdStopien)
                    .HasConstraintName("StopnieTytuly_Dydaktyk_FK1");

                entity.HasOne(d => d.PodlegaNavigation)
                    .WithMany(p => p.InversePodlegaNavigation)
                    .HasForeignKey(d => d.Podlega)
                    .HasConstraintName("Dydaktyk_Dydaktyk_FK1");
            });

            modelBuilder.Entity<Grupa>(entity =>
            {
                entity.HasKey(e => e.IdGrupa);

                entity.HasIndex(e => new { e.NrGrupy, e.IdRokAkademicki })
                    .HasName("UQ_Rok_Nr")
                    .IsUnique();

                entity.Property(e => e.IdRokAkademicki)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NrGrupy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRokAkademickiNavigation)
                    .WithMany(p => p.Grupa)
                    .HasForeignKey(d => d.IdRokAkademicki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RokAkad_GrupaStud_FK1");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.ToTable("klient");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CzyRodzina).HasColumnName("czyRodzina");

                entity.Property(e => e.CzyStudent).HasColumnName("czyStudent");
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.DataWystawienia, e.IdPrzedmiot });

                entity.Property(e => e.DataWystawienia).HasColumnType("date");

                entity.Property(e => e.Ocena1)
                    .HasColumnName("Ocena")
                    .HasColumnType("decimal(2, 1)");

                entity.HasOne(d => d.IdDydaktykNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdDydaktyk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Dydaktyk_Ocena_FK1");

                entity.HasOne(d => d.IdPrzedmiotNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdPrzedmiot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przedmiot_Ocena_FK1");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.Ocena)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Ocena_FK1");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.IdOsoba);

                entity.Property(e => e.DataUrodzenia).HasColumnType("date");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.Plec)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Panstwo>(entity =>
            {
                entity.HasKey(e => e.IdPanstwo);

                entity.Property(e => e.Panstwo1)
                    .IsRequired()
                    .HasColumnName("Panstwo")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("pizza");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaPizzy)
                    .HasColumnName("cena_pizzy")
                    .HasColumnType("money");

                entity.Property(e => e.NazwaPizzy)
                    .IsRequired()
                    .HasColumnName("nazwa_pizzy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SkladnikId).HasColumnName("skladnik_id");

                entity.Property(e => e.SosId).HasColumnName("sos_id");

                entity.HasOne(d => d.Skladnik)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SkladnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skladnik_pizza");

                entity.HasOne(d => d.Sos)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pizza_sos");
            });

            modelBuilder.Entity<Platnosc>(entity =>
            {
                entity.ToTable("platnosc");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CzyGotowka).HasColumnName("czyGotowka");

                entity.Property(e => e.CzyKarta).HasColumnName("czyKarta");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.ToTable("promocja");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaPromocji)
                    .IsRequired()
                    .HasColumnName("nazwa_promocji")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WartoscPromocji).HasColumnName("wartosc_promocji");
            });

            modelBuilder.Entity<Przedmiot>(entity =>
            {
                entity.HasKey(e => e.IdPrzedmiot);

                entity.Property(e => e.Przedmiot1)
                    .IsRequired()
                    .HasColumnName("Przedmiot")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrzedmiotPoprzedzajacy>(entity =>
            {
                entity.HasKey(e => new { e.IdPoprzednik, e.IdPrzedmiot });

                entity.HasOne(d => d.IdPoprzednikNavigation)
                    .WithMany(p => p.PrzedmiotPoprzedzajacyIdPoprzednikNavigation)
                    .HasForeignKey(d => d.IdPoprzednik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przedmiot_PrzedmiotPop_FK1");

                entity.HasOne(d => d.IdPrzedmiotNavigation)
                    .WithMany(p => p.PrzedmiotPoprzedzajacyIdPrzedmiotNavigation)
                    .HasForeignKey(d => d.IdPrzedmiot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Przedmiot_PrzedmiotPop_FK2");
            });

            modelBuilder.Entity<RokAkademicki>(entity =>
            {
                entity.HasKey(e => e.IdRokAkademicki);

                entity.Property(e => e.IdRokAkademicki)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DataRozp)
                    .HasColumnName("Data_rozp")
                    .HasColumnType("date");

                entity.Property(e => e.DataZak)
                    .HasColumnName("Data_zak")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.ToTable("skladnik");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaSkladnika)
                    .IsRequired()
                    .HasColumnName("nazwa_skladnika")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.ToTable("sos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaSosu)
                    .IsRequired()
                    .HasColumnName("nazwa_sosu")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StopnieTytuly>(entity =>
            {
                entity.HasKey(e => e.IdStopien);

                entity.Property(e => e.Skrot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Stopien)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdOsoba);

                entity.Property(e => e.IdOsoba).ValueGeneratedNever();

                entity.Property(e => e.DataRekrutacji).HasColumnType("date");

                entity.Property(e => e.NrIndeksu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Osoba_Student_FK1");
            });

            modelBuilder.Entity<StudentGrupa>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupa, e.IdOsoba });

                entity.HasOne(d => d.IdGrupaNavigation)
                    .WithMany(p => p.StudentGrupa)
                    .HasForeignKey(d => d.IdGrupa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Grupa_StudentGrupa_FK1");

                entity.HasOne(d => d.IdOsobaNavigation)
                    .WithMany(p => p.StudentGrupa)
                    .HasForeignKey(d => d.IdOsoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_StudentGrupa_FK1");
            });

            modelBuilder.Entity<Uprawnienia>(entity =>
            {
                entity.ToTable("uprawnienia");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Uprawnienia1)
                    .IsRequired()
                    .HasColumnName("uprawnienia")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUprawnien).HasColumnName("id_uprawnien");

                entity.HasOne(d => d.IdUprawnienNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUprawnien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uprawnienia_User");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.ToTable("zamowienie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaZamowienia)
                    .HasColumnName("cena_zamowienia")
                    .HasColumnType("money");

                entity.Property(e => e.DodatekId).HasColumnName("dodatek_id");

                entity.Property(e => e.DostawaId).HasColumnName("dostawa_id");

                entity.Property(e => e.KlientId).HasColumnName("klient_id");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.PlatnoscId).HasColumnName("platnosc_id");

                entity.Property(e => e.PromocjaId).HasColumnName("promocja_id");

                entity.HasOne(d => d.Dodatek)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DodatekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_dodatek");

                entity.HasOne(d => d.Dostawa)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.DostawaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_dostawa");

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.KlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_klient");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_pizza");

                entity.HasOne(d => d.Platnosc)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PlatnoscId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_platnosc");

                entity.HasOne(d => d.Promocja)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PromocjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienie_promocja");
            });
        }
    }
}
