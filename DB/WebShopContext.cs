using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebShop.DB;

public partial class WebShopContext : DbContext
{
    public WebShopContext()
    {
    }

    public WebShopContext(DbContextOptions<WebShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assortment> Assortments { get; set; }

    public virtual DbSet<Check> Checks { get; set; }

    public virtual DbSet<CorrespondencePositionPerson> CorrespondencePositionPeople { get; set; }

    public virtual DbSet<Counterparty> Counterparties { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<ListOfGoodsInTheCheck> ListOfGoodsInTheChecks { get; set; }

    public virtual DbSet<ListOfGoodsInThePriceList> ListOfGoodsInThePriceLists { get; set; }

    public virtual DbSet<ListOfGoodsInTheRequest> ListOfGoodsInTheRequests { get; set; }

    public virtual DbSet<ListOfProductsInAssortment> ListOfProductsInAssortments { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public virtual DbSet<RelocationRequest> RelocationRequests { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StructuralSubdivision> StructuralSubdivisions { get; set; }

    public virtual DbSet<TypesOfStructuralSubdivision> TypesOfStructuralSubdivisions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=DB\\\\\\\\WebShop.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assortment>(entity =>
        {
            entity.ToTable("assortment");

            entity.HasIndex(e => e.Id, "IX_assortment_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdSturcturalSubdivision).HasColumnName("id sturctural subdivision");

            entity.HasOne(d => d.IdSturcturalSubdivisionNavigation).WithMany(p => p.Assortments).HasForeignKey(d => d.IdSturcturalSubdivision);
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity.ToTable("check");

            entity.HasIndex(e => e.Id, "IX_check_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdPerson).HasColumnName("id person");
            entity.Property(e => e.IdStructuralSubdivision).HasColumnName("id structural subdivision");
            entity.Property(e => e.SerialNumber).HasColumnName("serial number");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Checks).HasForeignKey(d => d.IdPerson);

            entity.HasOne(d => d.IdStructuralSubdivisionNavigation).WithMany(p => p.Checks).HasForeignKey(d => d.IdStructuralSubdivision);
        });

        modelBuilder.Entity<CorrespondencePositionPerson>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("correspondence position person");

            entity.Property(e => e.DateOfEmployment).HasColumnName("date of employment");
            entity.Property(e => e.DateOfUnemployment).HasColumnName("date of unemployment");
            entity.Property(e => e.Id).HasColumnName("id ");
            entity.Property(e => e.IdPerson).HasColumnName("id person");
            entity.Property(e => e.PartTimeWorker).HasColumnName("part-time worker");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.IdNavigation).WithMany().HasForeignKey(d => d.Id);

            entity.HasOne(d => d.IdPersonNavigation).WithMany().HasForeignKey(d => d.IdPerson);
        });

        modelBuilder.Entity<Counterparty>(entity =>
        {
            entity.ToTable("counterparty");

            entity.HasIndex(e => e.Id, "IX_counterparty_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.BanksName).HasColumnName("banks name");
            entity.Property(e => e.CurrentAccountNumber).HasColumnName("current account number");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.ToTable("goods");

            entity.HasIndex(e => e.Id, "IX_goods_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdUnit).HasColumnName("id unit");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.Goods).HasForeignKey(d => d.IdUnit);
        });

        modelBuilder.Entity<ListOfGoodsInTheCheck>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("list of goods in the check");

            entity.Property(e => e.IdCheck).HasColumnName("id check");
            entity.Property(e => e.IdGoods).HasColumnName("id goods");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCheckNavigation).WithMany().HasForeignKey(d => d.IdCheck);

            entity.HasOne(d => d.IdGoodsNavigation).WithMany().HasForeignKey(d => d.IdGoods);
        });

        modelBuilder.Entity<ListOfGoodsInThePriceList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("list of goods in the price list");

            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdGoods).HasColumnName("id goods");
            entity.Property(e => e.IdPrice).HasColumnName("id price");

            entity.HasOne(d => d.IdGoodsNavigation).WithMany().HasForeignKey(d => d.IdGoods);

            entity.HasOne(d => d.IdPriceNavigation).WithMany().HasForeignKey(d => d.IdPrice);
        });

        modelBuilder.Entity<ListOfGoodsInTheRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("list of goods in the request");

            entity.Property(e => e.IdGoods).HasColumnName("id goods");
            entity.Property(e => e.IdRequest).HasColumnName("id request");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdGoodsNavigation).WithMany().HasForeignKey(d => d.IdGoods);

            entity.HasOne(d => d.IdRequestNavigation).WithMany().HasForeignKey(d => d.IdRequest);
        });

        modelBuilder.Entity<ListOfProductsInAssortment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("list of products in assortment");

            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdAssortiment).HasColumnName("id assortiment");
            entity.Property(e => e.IdGoods).HasColumnName("id goods");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdAssortimentNavigation).WithMany().HasForeignKey(d => d.IdAssortiment);

            entity.HasOne(d => d.IdGoodsNavigation).WithMany().HasForeignKey(d => d.IdGoods);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.ToTable("organization");

            entity.HasIndex(e => e.Id, "IX_organization_id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_organization_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LegalAddress).HasColumnName("legal address");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");

            entity.HasIndex(e => e.Id, "IX_person_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FatherName).HasColumnName("father name");
            entity.Property(e => e.IdStructuralSubdivision).HasColumnName("id structural subdivision");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PassportNumber).HasColumnName("passport number");
            entity.Property(e => e.PassportSeries).HasColumnName("passport series");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Snils).HasColumnName("snils");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.TelephoneNumber).HasColumnName("telephone number");

            entity.HasOne(d => d.IdStructuralSubdivisionNavigation).WithMany(p => p.People).HasForeignKey(d => d.IdStructuralSubdivision);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("position");

            entity.HasIndex(e => e.Id, "IX_position_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.ToTable("price");

            entity.HasIndex(e => e.Id, "IX_price_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCounterparty).HasColumnName("id counterparty");

            entity.HasOne(d => d.IdCounterpartyNavigation).WithMany(p => p.Prices).HasForeignKey(d => d.IdCounterparty);
        });

        modelBuilder.Entity<PurchaseRequest>(entity =>
        {
            entity.ToTable("purchase request");

            entity.HasIndex(e => e.Id, "IX_purchase request_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCounterparty).HasColumnName("id counterparty");
            entity.Property(e => e.IdRequest).HasColumnName("id request");

            entity.HasOne(d => d.IdCounterpartyNavigation).WithMany(p => p.PurchaseRequests).HasForeignKey(d => d.IdCounterparty);

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.PurchaseRequests).HasForeignKey(d => d.IdRequest);
        });

        modelBuilder.Entity<RelocationRequest>(entity =>
        {
            entity.ToTable("relocation request");

            entity.HasIndex(e => e.Id, "IX_relocation request_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRequest).HasColumnName("id request");
            entity.Property(e => e.IdStructuralSubdivision).HasColumnName("id structural subdivision");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.RelocationRequests)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdStructuralSubdivisionNavigation).WithMany(p => p.RelocationRequests)
                .HasForeignKey(d => d.IdStructuralSubdivision)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("request");

            entity.HasIndex(e => e.Id, "IX_request_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdStructuralSubdivision).HasColumnName("id structural subdivision");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdStructuralSubdivisionNavigation).WithMany(p => p.Requests).HasForeignKey(d => d.IdStructuralSubdivision);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.HasIndex(e => e.Id, "IX_role_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<StructuralSubdivision>(entity =>
        {
            entity.ToTable("structural subdivision");

            entity.HasIndex(e => e.Id, "IX_structural subdivision_id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_structural subdivision_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.IdOfType).HasColumnName("id of type");
            entity.Property(e => e.IdOrganization).HasColumnName("id organization");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdOfTypeNavigation).WithMany(p => p.StructuralSubdivisions)
                .HasForeignKey(d => d.IdOfType)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdOrganizationNavigation).WithMany(p => p.StructuralSubdivisions).HasForeignKey(d => d.IdOrganization);
        });

        modelBuilder.Entity<TypesOfStructuralSubdivision>(entity =>
        {
            entity.ToTable("types of structural subdivisions");

            entity.HasIndex(e => e.Id, "IX_types of structural subdivisions_id").IsUnique();

            entity.HasIndex(e => e.Type, "IX_types of structural subdivisions_type").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("unit");

            entity.HasIndex(e => e.Id, "IX_unit_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasIndex(e => e.Id, "IX_user_id").IsUnique();

            entity.HasIndex(e => e.Login, "IX_user_login").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.OrganizationId).HasColumnName("organization id");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("person id");
            entity.Property(e => e.RoleId).HasColumnName("role id");

            entity.HasOne(d => d.Organization).WithMany(p => p.Users).HasForeignKey(d => d.OrganizationId);

            entity.HasOne(d => d.Person).WithMany(p => p.Users).HasForeignKey(d => d.PersonId);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
