using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Država> Državas { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Korisnik> Korisniks { get; set; } = null!;
        public virtual DbSet<Ocjenio> Ocjenios { get; set; } = null!;
        public virtual DbSet<Račun> Računs { get; set; } = null!;
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; } = null!;
        public virtual DbSet<Soba> Sobas { get; set; } = null!;
        public virtual DbSet<StatusRezervacije> StatusRezervacijes { get; set; } = null!;
        public virtual DbSet<TipKorisnika> TipKorisnikas { get; set; } = null!;
        public virtual DbSet<TipSobe> TipSobes { get; set; } = null!;
        public virtual DbSet<Zaposlenik> Zaposleniks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Država>(entity =>
            {
                entity.HasKey(e => e.OznakaDrzave);

                entity.ToTable("Država");

                entity.Property(e => e.OznakaDrzave)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("oznaka_drzave")
                    .IsFixedLength();

                entity.Property(e => e.Naziv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojKatova).HasColumnName("broj_katova");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.OznakaDrzave)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("oznaka_drzave")
                    .IsFixedLength();

                entity.Property(e => e.ProsjecnaOcjena)
                    .HasColumnName("prosjecna_ocjena")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.OznakaDrzaveNavigation)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.OznakaDrzave)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Hotel_Država");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Ime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lozinka");

                entity.Property(e => e.LozinkaSol)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lozinka_sol");

                entity.Property(e => e.PostanskiBroj)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("postanski_broj");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("prezime");

                entity.Property(e => e.TipKorisnikaId).HasColumnName("tip_korisnika_id");

                entity.HasOne(d => d.TipKorisnika)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.TipKorisnikaId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Korisnik_TipKorisnika");
            });

            modelBuilder.Entity<Ocjenio>(entity =>
            {
                entity.HasKey(e => new { e.KorisnikId, e.HotelId });

                entity.ToTable("Ocjenio");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Ocjenios)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Ocjenio_Hotel");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ocjenios)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Ocjenio_Korisnik");
            });

            modelBuilder.Entity<Račun>(entity =>
            {
                entity.HasKey(e => new { e.RezervacijaId, e.ZaposlenikId });

                entity.ToTable("Račun");

                entity.Property(e => e.RezervacijaId).HasColumnName("rezervacija_id");

                entity.Property(e => e.ZaposlenikId).HasColumnName("zaposlenik_id");

                entity.Property(e => e.Placeno).HasColumnName("placeno");

                entity.Property(e => e.UkupnaCijena).HasColumnName("ukupna_cijena");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Računs)
                    .HasForeignKey(d => d.RezervacijaId)
                    .HasConstraintName("FK_Račun_Rezervacija");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Računs)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Račun_Zaposlenik");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.ToTable("Rezervacija");

                entity.Property(e => e.RezervacijaId).HasColumnName("rezervacija_id");

                entity.Property(e => e.BrojNocenja).HasColumnName("broj_nocenja");

                entity.Property(e => e.DatumRezervacije)
                    .HasColumnType("date")
                    .HasColumnName("datum_rezervacije");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.OznakaStatusa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("oznaka_statusa")
                    .IsFixedLength();

                entity.Property(e => e.RezervacijaDo)
                    .HasColumnType("date")
                    .HasColumnName("rezervacija_do");

                entity.Property(e => e.RezervacijaOd)
                    .HasColumnType("date")
                    .HasColumnName("rezervacija_od");

                entity.Property(e => e.SobaId).HasColumnName("soba_id");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Rezervacija_Korisnik");

                entity.HasOne(d => d.OznakaStatusaNavigation)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.OznakaStatusa)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Rezervacija_StatusRezervacije");

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.SobaId)
                    .HasConstraintName("FK_Rezervacija_Soba");
            });

            modelBuilder.Entity<Soba>(entity =>
            {
                entity.ToTable("Soba");

                entity.Property(e => e.SobaId).HasColumnName("soba_id");

                entity.Property(e => e.BrojKata).HasColumnName("broj_kata");

                entity.Property(e => e.BrojSobe).HasColumnName("broj_sobe");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Rezervirana).HasColumnName("rezervirana");

                entity.Property(e => e.TipSobeId).HasColumnName("tip_sobe_id");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Sobas)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Soba_Hotel");

                entity.HasOne(d => d.TipSobe)
                    .WithMany(p => p.Sobas)
                    .HasForeignKey(d => d.TipSobeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Soba_TipSobe");
            });

            modelBuilder.Entity<StatusRezervacije>(entity =>
            {
                entity.HasKey(e => e.OznakaStatusa);

                entity.ToTable("StatusRezervacije");

                entity.Property(e => e.OznakaStatusa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("oznaka_statusa")
                    .IsFixedLength();

                entity.Property(e => e.Naziv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<TipKorisnika>(entity =>
            {
                entity.ToTable("TipKorisnika");

                entity.Property(e => e.TipKorisnikaId).HasColumnName("tip_korisnika_id");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<TipSobe>(entity =>
            {
                entity.ToTable("TipSobe");

                entity.Property(e => e.TipSobeId).HasColumnName("tip_sobe_id");

                entity.Property(e => e.CijenaPoNocenju).HasColumnName("cijena_po_nocenju");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.ToTable("Zaposlenik");

                entity.Property(e => e.ZaposlenikId).HasColumnName("zaposlenik_id");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adresa");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Ime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("prezime");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Zaposleniks)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Zaposlenik_Hotel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
