using Auto_Manager_Hub.DataAccess.Functions.TVF;
using Auto_Manager_Hub.DataAccess.Views;
using Auto_Manager_Hub.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Auto_Manager_Hub.DataAccess.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Body> TblBodies { get; set; }

    public virtual DbSet<Models.Models.DriveType> TblDriveTypes { get; set; }

    public virtual DbSet<FuelType> TblFuelTypes { get; set; }

    public virtual DbSet<Make> TblMakes { get; set; }

    public virtual DbSet<MakeModel> TblMakeModels { get; set; }

    public virtual DbSet<SubModel> TblSubModels { get; set; }

    public virtual DbSet<VehicleDetail> TblVehicleDetails { get; set; }

    public virtual DbSet<MakesModelsWithSubModels> MakeModelsWithSubModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = Vehicle_Management; TrustServerCertificate = True; Integrated Security = SSPI");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Body>(entity =>
        {
            entity.HasKey(e => e.BodyId).HasName("PK_Bodies");

            entity.ToTable("tbl_Bodies");

            entity.Property(e => e.BodyId).HasColumnName("Body_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.BodyName)
                .HasMaxLength(50)
                .HasColumnName("Body_Name");
        });

        modelBuilder.Entity<Models.Models.DriveType>(entity =>
        {
            entity.HasKey(e => e.DriveTypeId).HasName("PK_DriveTypes");

            entity.ToTable("tbl_Drive_Types");

            entity.Property(e => e.DriveTypeId).HasColumnName("Drive_Type_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.DType)
                .HasMaxLength(50)
                .HasColumnName("Drive_Type_Name");
        });

        modelBuilder.Entity<FuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypeId).HasName("PK_FuleTypes");

            entity.ToTable("tbl_Fuel_Types");

            entity.Property(e => e.FuelTypeId).HasColumnName("Fuel_Type_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.FuelTypeName)
                .HasMaxLength(50)
                .HasColumnName("Fuel_Type_Name");
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasKey(e => e.MakeId).HasName("PK_Make");

            entity.ToTable("tbl_Makes");

            entity.Property(e => e.MakeId).HasColumnName("Make_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MakeName).HasMaxLength(100);
        });

        modelBuilder.Entity<MakeModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK_MakeModels");

            entity.ToTable("tbl_Make_Models");

            entity.Property(e => e.ModelId).HasColumnName("Model_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.MakeId).HasColumnName("Make_ID");
            entity.Property(e => e.ModelName)
                .HasMaxLength(100)
                .HasColumnName("Model_Name");

            entity.HasOne(d => d.Make).WithMany(p => p.TblMakeModels)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MakeModels_Makes");
        });

        modelBuilder.Entity<SubModel>(entity =>
        {
            entity.HasKey(e => e.SubModelId).HasName("PK_SubModels");

            entity.ToTable("tbl_SubModels");

            entity.Property(e => e.SubModelId).HasColumnName("SubModel_ID").ValueGeneratedOnAdd();
            entity.Property(e => e.ModelId).HasColumnName("Model_ID");
            entity.Property(e => e.SubModelName)
                .HasMaxLength(100)
                .HasColumnName("SubModel_Name");

            entity.HasOne(d => d.Model).WithMany(p => p.TblSubModels)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModels_MakeModels");
        });

        modelBuilder.Entity<VehicleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CarDetails");

            entity.ToTable("tbl_Vehicle_Details");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.BodyId).HasColumnName("Body_ID");
            entity.Property(e => e.DriveTypeId).HasColumnName("Drive_Type_ID");
            entity.Property(e => e.Engine).HasMaxLength(100);
            entity.Property(e => e.EngineCc).HasColumnName("Engine_CC");
            entity.Property(e => e.EngineCylinders).HasColumnName("Engine_Cylinders");
            entity.Property(e => e.EngineLiterDisplay)
                .HasColumnType("money")
                .HasColumnName("Engine_Liter_Display");
            entity.Property(e => e.FuelTypeId).HasColumnName("Fuel_Type_ID");
            entity.Property(e => e.MakeId).HasColumnName("Make_ID");
            entity.Property(e => e.ModelId).HasColumnName("Model_ID");
            entity.Property(e => e.NumDoors).HasColumnName("Num_Doors");
            entity.Property(e => e.SubModelId).HasColumnName("SubModel_ID");
            entity.Property(e => e.VehicleDisplayName)
                .HasMaxLength(150)
                .HasColumnName("Vehicle_Display_Name");

            entity.HasOne(d => d.Body).WithMany(p => p.TblVehicleDetails)
                .HasForeignKey(d => d.BodyId)
                .HasConstraintName("FK_VehicleDetails_Bodies");

            entity.HasOne(d => d.DriveType).WithMany(p => p.VehicleDetails)
                .HasForeignKey(d => d.DriveTypeId)
                .HasConstraintName("FK_VehicleDetails_DriveTypes");

            entity.HasOne(d => d.FuelType).WithMany(p => p.TblVehicleDetails)
                .HasForeignKey(d => d.FuelTypeId)
                .HasConstraintName("FK_VehicleDetails_FuelTypes");

            entity.HasOne(d => d.SubModel).WithMany(p => p.TblVehicleDetails)
                .HasForeignKey(d => d.SubModelId)
                .HasConstraintName("FK_VehicleDetails_SubModels");
        });

        //modelBuilder.Entity<VehicleMasterDetail>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("VehicleMasterDetails");

        //    entity.Property(e => e.BodyId).HasColumnName("BodyID");
        //    entity.Property(e => e.BodyName).HasMaxLength(50);
        //    entity.Property(e => e.DriveTypeId).HasColumnName("DriveTypeID");
        //    entity.Property(e => e.DriveTypeName).HasMaxLength(50);
        //    entity.Property(e => e.Engine).HasMaxLength(100);
        //    entity.Property(e => e.EngineCc).HasColumnName("Engine_CC");
        //    entity.Property(e => e.EngineCylinders).HasColumnName("Engine_Cylinders");
        //    entity.Property(e => e.EngineLiterDisplay)
        //        .HasColumnType("money")
        //        .HasColumnName("Engine_Liter_Display");
        //    entity.Property(e => e.FuelTypeId).HasColumnName("FuelTypeID");
        //    entity.Property(e => e.FuelTypeName).HasMaxLength(50);
        //    entity.Property(e => e.Id).HasColumnName("ID");
        //    entity.Property(e => e.Make).HasMaxLength(100);
        //    entity.Property(e => e.MakeId).HasColumnName("MakeID");
        //    entity.Property(e => e.ModelId).HasColumnName("ModelID");
        //    entity.Property(e => e.ModelName).HasMaxLength(100);
        //    entity.Property(e => e.SubModelId).HasColumnName("SubModelID");
        //    entity.Property(e => e.SubModelName).HasMaxLength(100);
        //    entity.Property(e => e.VehicleDisplayName)
        //        .HasMaxLength(150)
        //        .HasColumnName("Vehicle_Display_Name");
        //});

        // Views :
        modelBuilder.Entity<MakesModelsWithSubModels>()
            .ToView("vwGetMakesModelsWithSubModels")
            .HasNoKey();

        modelBuilder.Entity<MakesModelsWithSubModels>()
            .Property(e => e.MakeID)
            .HasColumnName("Make_ID")
            .HasColumnType("int");

        modelBuilder.Entity<MakesModelsWithSubModels>()
            .Property(e => e.MakeName)
            .HasColumnName("Make_Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        modelBuilder.Entity<MakesModelsWithSubModels>()
            .Property(e => e.MakeName)
            .HasColumnName("Model_Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        modelBuilder.Entity<MakesModelsWithSubModels>()
            .Property(e => e.MakeName)
            .HasColumnName("SubModel_Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        // functions:
        modelBuilder.Entity<MakeModelsWithSubModels>()
            .Property(e => e.Make_ID)
            .HasColumnName("Make_ID");  
        
        modelBuilder.Entity<MakeModelsWithSubModels>()
            .Property(e => e.Make_Name)
            .HasColumnName("MakeName");

        modelBuilder.Entity<MakeModelsWithSubModels>()
            .Property(e => e.Model_Name)
            .HasColumnName("Model_Name");

        modelBuilder.Entity<MakeModelsWithSubModels>()
            .Property(e => e.SubModel_Name)
            .HasColumnName("SubModel_Name");

        modelBuilder.Entity<MakeModelsWithSubModels>().HasNoKey();
        modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(fnGetMakeModels), new[] { typeof(int) })!);

        OnModelCreatingPartial(modelBuilder);
    }

    public IQueryable<MakeModelsWithSubModels> fnGetMakeModels(int Make_ID)
        => FromExpression(() => fnGetMakeModels(Make_ID));

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
