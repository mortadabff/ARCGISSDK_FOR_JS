using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Géoportail.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BidonvileF> BidonvileFs { get; set; }

    public virtual DbSet<Dbtune> Dbtunes { get; set; }

    public virtual DbSet<GdbItem> GdbItems { get; set; }

    public virtual DbSet<GdbItemrelationship> GdbItemrelationships { get; set; }

    public virtual DbSet<GdbItemrelationshiptype> GdbItemrelationshiptypes { get; set; }

    public virtual DbSet<GdbItemtype> GdbItemtypes { get; set; }

    public virtual DbSet<GdbReplicalog> GdbReplicalogs { get; set; }

    public virtual DbSet<GdbTablesLastModified> GdbTablesLastModifieds { get; set; }

    public virtual DbSet<I10> I10s { get; set; }

    public virtual DbSet<I2> I2s { get; set; }

    public virtual DbSet<I3> I3s { get; set; }

    public virtual DbSet<I4> I4s { get; set; }

    public virtual DbSet<I5> I5s { get; set; }

    public virtual DbSet<I6> I6s { get; set; }

    public virtual DbSet<I7> I7s { get; set; }

    public virtual DbSet<I8> I8s { get; set; }

    public virtual DbSet<Infraction> Infractions { get; set; }

    public virtual DbSet<Reclamatiosn> Reclamatiosns { get; set; }

    public virtual DbSet<SdeArchive> SdeArchives { get; set; }

    public virtual DbSet<SdeColumnRegistry> SdeColumnRegistries { get; set; }

    public virtual DbSet<SdeDbtune> SdeDbtunes { get; set; }

    public virtual DbSet<SdeGenerateGuid> SdeGenerateGuids { get; set; }

    public virtual DbSet<SdeGeometry1> SdeGeometry1s { get; set; }

    public virtual DbSet<SdeGeometry2> SdeGeometry2s { get; set; }

    public virtual DbSet<SdeGeometry3> SdeGeometry3s { get; set; }

    public virtual DbSet<SdeGeometry5> SdeGeometry5s { get; set; }

    public virtual DbSet<SdeGeometryColumn> SdeGeometryColumns { get; set; }

    public virtual DbSet<SdeLayer> SdeLayers { get; set; }

    public virtual DbSet<SdeLayerLock> SdeLayerLocks { get; set; }

    public virtual DbSet<SdeLayerStat> SdeLayerStats { get; set; }

    public virtual DbSet<SdeLineagesModified> SdeLineagesModifieds { get; set; }

    public virtual DbSet<SdeLocator> SdeLocators { get; set; }

    public virtual DbSet<SdeLogfilePool> SdeLogfilePools { get; set; }

    public virtual DbSet<SdeMetadatum> SdeMetadata { get; set; }

    public virtual DbSet<SdeObjectId> SdeObjectIds { get; set; }

    public virtual DbSet<SdeObjectLock> SdeObjectLocks { get; set; }

    public virtual DbSet<SdeProcessInformation> SdeProcessInformations { get; set; }

    public virtual DbSet<SdeRasterColumn> SdeRasterColumns { get; set; }

    public virtual DbSet<SdeServerConfig> SdeServerConfigs { get; set; }

    public virtual DbSet<SdeSpatialReference> SdeSpatialReferences { get; set; }

    public virtual DbSet<SdeState> SdeStates { get; set; }

    public virtual DbSet<SdeStateLineage> SdeStateLineages { get; set; }

    public virtual DbSet<SdeStateLock> SdeStateLocks { get; set; }

    public virtual DbSet<SdeTableLock> SdeTableLocks { get; set; }

    public virtual DbSet<SdeTableRegistry> SdeTableRegistries { get; set; }

    public virtual DbSet<SdeTablesModified> SdeTablesModifieds { get; set; }

    public virtual DbSet<SdeVersion> SdeVersions { get; set; }

    public virtual DbSet<SdeVersion1> SdeVersions1 { get; set; }

    public virtual DbSet<SdeXmlColumn> SdeXmlColumns { get; set; }

    public virtual DbSet<SdeXmlIndex> SdeXmlIndexes { get; set; }

    public virtual DbSet<SdeXmlIndexTag> SdeXmlIndexTags { get; set; }

    public virtual DbSet<StGeometryColumn> StGeometryColumns { get; set; }

    public virtual DbSet<StSpatialReferenceSystem> StSpatialReferenceSystems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CasablancaDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BidonvileF>(entity =>
        {
            entity.HasKey(e => e.Objectid1).HasName("R8_pk");

            entity.ToTable("BIDONVILE_FS");

            entity.Property(e => e.Objectid1)
                .ValueGeneratedNever()
                .HasColumnName("OBJECTID_1");
            entity.Property(e => e.Commune)
                .HasMaxLength(100)
                .HasColumnName("COMMUNE");
            entity.Property(e => e.Etat)
                .HasMaxLength(50)
                .HasColumnName("ETAT");
            entity.Property(e => e.FidSiteAc)
                .HasMaxLength(2)
                .HasColumnName("FID_SiteAc");
            entity.Property(e => e.NearDist)
                .HasColumnType("numeric(38, 8)")
                .HasColumnName("NEAR_DIST");
            entity.Property(e => e.NearFid).HasColumnName("NEAR_FID");
            entity.Property(e => e.NearX)
                .HasColumnType("numeric(38, 8)")
                .HasColumnName("NEAR_X");
            entity.Property(e => e.NearY)
                .HasColumnType("numeric(38, 8)")
                .HasColumnName("NEAR_Y");
            entity.Property(e => e.NomDouar)
                .HasMaxLength(50)
                .HasColumnName("NOM_DOUAR");
            entity.Property(e => e.Objectid).HasColumnName("OBJECTID");
            entity.Property(e => e.Prefecture)
                .HasMaxLength(50)
                .HasColumnName("PREFECTURE");
            entity.Property(e => e.ShapeLeng)
                .HasColumnType("numeric(38, 8)")
                .HasColumnName("SHAPE_Leng");
        });

        modelBuilder.Entity<Dbtune>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("dbtune");

            entity.Property(e => e.ConfigString)
                .HasMaxLength(2048)
                .HasColumnName("config_string");
            entity.Property(e => e.Keyword)
                .HasMaxLength(32)
                .HasColumnName("keyword");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(32)
                .HasColumnName("parameter_name");
        });

        modelBuilder.Entity<GdbItem>(entity =>
        {
            entity.HasKey(e => e.ObjectId).HasName("R2_pk");

            entity.ToTable("GDB_ITEMS", tb => tb.HasTrigger("GDB_ITEMS_TAB_TR"));

            entity.HasIndex(e => e.Uuid, "GDB_Items_UUID_idx")
                .IsUnique()
                .HasFillFactor(75);

            entity.HasIndex(e => e.Name, "Items_Name_idx").HasFillFactor(75);

            entity.HasIndex(e => e.PhysicalName, "Items_PhysicalName_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Type, "Items_Type_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Definition, "xmlpath_GDB_ITEMS_Definition");

            entity.HasIndex(e => e.Documentation, "xmlpath_GDB_ITEMS_Documentation");

            entity.HasIndex(e => e.ItemInfo, "xmlpath_GDB_ITEMS_ItemInfo");

            entity.HasIndex(e => e.Definition, "xmlprim_GDB_ITEMS_Definition");

            entity.HasIndex(e => e.Documentation, "xmlprim_GDB_ITEMS_Documentation");

            entity.HasIndex(e => e.ItemInfo, "xmlprim_GDB_ITEMS_ItemInfo");

            entity.HasIndex(e => e.Definition, "xmlval_GDB_ITEMS_Definition");

            entity.HasIndex(e => e.Documentation, "xmlval_GDB_ITEMS_Documentation");

            entity.HasIndex(e => e.ItemInfo, "xmlval_GDB_ITEMS_ItemInfo");

            entity.Property(e => e.ObjectId)
                .ValueGeneratedNever()
                .HasColumnName("ObjectID");
            entity.Property(e => e.DatasetInfo1).HasMaxLength(255);
            entity.Property(e => e.DatasetInfo2).HasMaxLength(255);
            entity.Property(e => e.Definition).HasColumnType("xml");
            entity.Property(e => e.Documentation).HasColumnType("xml");
            entity.Property(e => e.ItemInfo).HasColumnType("xml");
            entity.Property(e => e.Name).HasMaxLength(226);
            entity.Property(e => e.Path).HasMaxLength(512);
            entity.Property(e => e.PhysicalName).HasMaxLength(226);
            entity.Property(e => e.Url).HasMaxLength(255);
            entity.Property(e => e.Uuid).HasColumnName("UUID");
        });

        modelBuilder.Entity<GdbItemrelationship>(entity =>
        {
            entity.HasKey(e => e.ObjectId).HasName("R3_pk");

            entity.ToTable("GDB_ITEMRELATIONSHIPS", tb => tb.HasTrigger("GDB_ITEMS_REL_TR"));

            entity.HasIndex(e => e.DestId, "GDB_ItemRel_DestID_idx").HasFillFactor(75);

            entity.HasIndex(e => e.OriginId, "GDB_ItemRel_OriginID_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Type, "GDB_ItemRel_Type_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Uuid, "GDB_ItemRelationships_UUID_idx")
                .IsUnique()
                .HasFillFactor(75);

            entity.HasIndex(e => e.Attributes, "xmlpath_GDB_ITEMRELATIONSHIPS_Attributes");

            entity.HasIndex(e => e.Attributes, "xmlprim_GDB_ITEMRELATIONSHIPS_Attributes");

            entity.HasIndex(e => e.Attributes, "xmlval_GDB_ITEMRELATIONSHIPS_Attributes");

            entity.Property(e => e.ObjectId)
                .ValueGeneratedNever()
                .HasColumnName("ObjectID");
            entity.Property(e => e.Attributes).HasColumnType("xml");
            entity.Property(e => e.DestId).HasColumnName("DestID");
            entity.Property(e => e.OriginId).HasColumnName("OriginID");
            entity.Property(e => e.Uuid).HasColumnName("UUID");
        });

        modelBuilder.Entity<GdbItemrelationshiptype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GDB_ITEMRELATIONSHIPTYPES", tb => tb.HasTrigger("GDB_ITEM_REL_TYP_TR"));

            entity.HasIndex(e => e.BackwardLabel, "ItmRTypes_BackwardLabel_idx").HasFillFactor(75);

            entity.HasIndex(e => e.DestItemTypeId, "ItmRTypes_DestItemTypeID_idx").HasFillFactor(75);

            entity.HasIndex(e => e.ForwardLabel, "ItmRTypes_ForwardLabel_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Name, "ItmRTypes_Name_idx").HasFillFactor(75);

            entity.HasIndex(e => e.OrigItemTypeId, "ItmRTypes_OrigItemTypeID_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Uuid, "ItmRTypes_UUID_idx")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => e.ObjectId, "R5_SDE_ROWID_UK")
                .IsUnique()
                .HasFillFactor(75);

            entity.Property(e => e.BackwardLabel).HasMaxLength(226);
            entity.Property(e => e.DestItemTypeId).HasColumnName("DestItemTypeID");
            entity.Property(e => e.ForwardLabel).HasMaxLength(226);
            entity.Property(e => e.Name).HasMaxLength(226);
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.OrigItemTypeId).HasColumnName("OrigItemTypeID");
            entity.Property(e => e.Uuid).HasColumnName("UUID");
        });

        modelBuilder.Entity<GdbItemtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GDB_ITEMTYPES", tb => tb.HasTrigger("GDB_ITEM_TYP_TR"));

            entity.HasIndex(e => e.Name, "ItemTypes_Name_idx").HasFillFactor(75);

            entity.HasIndex(e => e.ParentTypeId, "ItemTypes_ParentTypeID_idx").HasFillFactor(75);

            entity.HasIndex(e => e.Uuid, "ItemTypes_UUID_idx")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => e.ObjectId, "R4_SDE_ROWID_UK")
                .IsUnique()
                .HasFillFactor(75);

            entity.Property(e => e.Name).HasMaxLength(226);
            entity.Property(e => e.ObjectId).HasColumnName("ObjectID");
            entity.Property(e => e.ParentTypeId).HasColumnName("ParentTypeID");
            entity.Property(e => e.Uuid).HasColumnName("UUID");
        });

        modelBuilder.Entity<GdbReplicalog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GDB_REPLICALOG", tb => tb.HasTrigger("GDB_REP_LOG_TR"));

            entity.HasIndex(e => e.Id, "R6_SDE_ROWID_UK")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ReplicaId).HasColumnName("ReplicaID");
        });

        modelBuilder.Entity<GdbTablesLastModified>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GDB_TABLES_LAST_MODIFIED");

            entity.HasIndex(e => e.TableName, "GDB_LMODIFIED_IX1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.LastModifiedCount).HasColumnName("last_modified_count");
            entity.Property(e => e.TableName)
                .HasMaxLength(160)
                .HasColumnName("table_name");
        });

        modelBuilder.Entity<I10>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i10_pk");

            entity.ToTable("i10");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I2>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i2_pk");

            entity.ToTable("i2");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I3>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i3_pk");

            entity.ToTable("i3");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I4>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i4_pk");

            entity.ToTable("i4");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I5>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i5_pk");

            entity.ToTable("i5");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I6>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i6_pk");

            entity.ToTable("i6");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I7>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i7_pk");

            entity.ToTable("i7");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<I8>(entity =>
        {
            entity.HasKey(e => new { e.IdType, e.NumIds, e.BaseId }).HasName("i8_pk");

            entity.ToTable("i8");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.NumIds).HasColumnName("num_ids");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.LastId).HasColumnName("last_id");
        });

        modelBuilder.Entity<Infraction>(entity =>
        {
            entity.HasKey(e => e.Objectid).HasName("R7_pk");

            entity.ToTable("INFRACTIONS");

            entity.Property(e => e.Objectid)
                .ValueGeneratedNever()
                .HasColumnName("OBJECTID");
            entity.Property(e => e.Objet).HasMaxLength(50);
            entity.Property(e => e.Prefecture).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });
        /*
        modelBuilder.Entity<Reclamatiosn>(entity =>
        {
            entity.HasKey(e => e.Objectid1).HasName("R10_pk");

            entity.ToTable("RECLAMATIOSN");

            entity.Property(e => e.Objectid1)
                .ValueGeneratedNever()
                .HasColumnName("OBJECTID_1");
            entity.Property(e => e.DemarcheD)
                .HasMaxLength(250)
                .HasColumnName("Demarche_d");
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(250);
            entity.Property(e => e.Objectid).HasColumnName("OBJECTID");
            entity.Property(e => e.Objet).HasMaxLength(100);
        });
        */
        modelBuilder.Entity<Reclamatiosn>(entity =>
        {
            entity.HasKey(e => e.Objectid1).HasName("R10_pk");

            entity.ToTable("RECLAMATIOSN");

            entity.Property(e => e.Objectid1)
                .ValueGeneratedOnAdd() // Configure the primary key to be auto-generated
                .HasColumnName("OBJECTID_1");
            entity.Property(e => e.DemarcheD)
                .HasMaxLength(250)
                .HasColumnName("Demarche_d");
            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(250);
            entity.Property(e => e.Objectid).HasColumnName("OBJECTID");
            entity.Property(e => e.Objet).HasMaxLength(100);
        });


        modelBuilder.Entity<SdeArchive>(entity =>
        {
            entity.HasKey(e => e.ArchivingRegid).HasName("archives_pk");

            entity.ToTable("SDE_archives");

            entity.HasIndex(e => e.HistoryRegid, "archives_uk").IsUnique();

            entity.Property(e => e.ArchivingRegid)
                .ValueGeneratedNever()
                .HasColumnName("archiving_regid");
            entity.Property(e => e.ArchiveDate).HasColumnName("archive_date");
            entity.Property(e => e.ArchiveFlags).HasColumnName("archive_flags");
            entity.Property(e => e.FromDate)
                .HasMaxLength(32)
                .HasColumnName("from_date");
            entity.Property(e => e.HistoryRegid).HasColumnName("history_regid");
            entity.Property(e => e.ToDate)
                .HasMaxLength(32)
                .HasColumnName("to_date");

            entity.HasOne(d => d.ArchivingReg).WithOne(p => p.SdeArchiveArchivingReg)
                .HasForeignKey<SdeArchive>(d => d.ArchivingRegid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("archives_fk1");

            entity.HasOne(d => d.HistoryReg).WithOne(p => p.SdeArchiveHistoryReg)
                .HasForeignKey<SdeArchive>(d => d.HistoryRegid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("archives_fk2");
        });

        modelBuilder.Entity<SdeColumnRegistry>(entity =>
        {
            entity.HasKey(e => new { e.DatabaseName, e.TableName, e.Owner, e.ColumnName }).HasName("colregistry_pk");

            entity.ToTable("SDE_column_registry");

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(32)
                .HasColumnName("database_name");
            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(32)
                .HasColumnName("column_name");
            entity.Property(e => e.ColumnSize).HasColumnName("column_size");
            entity.Property(e => e.DecimalDigits).HasColumnName("decimal_digits");
            entity.Property(e => e.Description)
                .HasMaxLength(65)
                .HasColumnName("description");
            entity.Property(e => e.ObjectFlags).HasColumnName("object_flags");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.SdeType).HasColumnName("sde_type");

            entity.HasOne(d => d.SdeTableRegistry).WithMany(p => p.SdeColumnRegistries)
                .HasPrincipalKey(p => new { p.TableName, p.Owner, p.DatabaseName })
                .HasForeignKey(d => new { d.TableName, d.Owner, d.DatabaseName })
                .HasConstraintName("colregistry_fk");
        });

        modelBuilder.Entity<SdeDbtune>(entity =>
        {
            entity.HasKey(e => new { e.Keyword, e.ParameterName }).HasName("dbtune_pk");

            entity.ToTable("SDE_dbtune");

            entity.Property(e => e.Keyword)
                .HasMaxLength(32)
                .HasColumnName("keyword");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(32)
                .HasColumnName("parameter_name");
            entity.Property(e => e.ConfigString)
                .HasMaxLength(2048)
                .HasColumnName("config_string");
        });

        modelBuilder.Entity<SdeGenerateGuid>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SDE_generate_guid");

            entity.Property(e => e.Guidstr)
                .HasMaxLength(38)
                .HasColumnName("guidstr");
        });

        modelBuilder.Entity<SdeGeometry1>(entity =>
        {
            entity.HasKey(e => e.GeometryId).HasName("geom1_idx");

            entity.ToTable("SDE_GEOMETRY1");

            entity.Property(e => e.GeometryId)
                .ValueGeneratedNever()
                .HasColumnName("GEOMETRY_ID");
            entity.Property(e => e.Cad).HasColumnName("CAD");
        });

        modelBuilder.Entity<SdeGeometry2>(entity =>
        {
            entity.HasKey(e => e.GeometryId).HasName("geom2_idx");

            entity.ToTable("SDE_GEOMETRY2");

            entity.Property(e => e.GeometryId)
                .ValueGeneratedNever()
                .HasColumnName("GEOMETRY_ID");
            entity.Property(e => e.Cad).HasColumnName("CAD");
        });

        modelBuilder.Entity<SdeGeometry3>(entity =>
        {
            entity.HasKey(e => e.GeometryId).HasName("geom3_idx");

            entity.ToTable("SDE_GEOMETRY3");

            entity.Property(e => e.GeometryId)
                .ValueGeneratedNever()
                .HasColumnName("GEOMETRY_ID");
            entity.Property(e => e.Cad).HasColumnName("CAD");
        });

        modelBuilder.Entity<SdeGeometry5>(entity =>
        {
            entity.HasKey(e => e.GeometryId).HasName("geom5_idx");

            entity.ToTable("SDE_GEOMETRY5");

            entity.Property(e => e.GeometryId)
                .ValueGeneratedNever()
                .HasColumnName("GEOMETRY_ID");
            entity.Property(e => e.Cad).HasColumnName("CAD");
        });

        modelBuilder.Entity<SdeGeometryColumn>(entity =>
        {
            entity.HasKey(e => new { e.FTableCatalog, e.FTableSchema, e.FTableName, e.FGeometryColumn }).HasName("geocol_pk");

            entity.ToTable("SDE_geometry_columns");

            entity.Property(e => e.FTableCatalog)
                .HasMaxLength(32)
                .HasColumnName("f_table_catalog");
            entity.Property(e => e.FTableSchema)
                .HasMaxLength(32)
                .HasColumnName("f_table_schema");
            entity.Property(e => e.FTableName)
                .HasMaxLength(128)
                .HasColumnName("f_table_name");
            entity.Property(e => e.FGeometryColumn)
                .HasMaxLength(32)
                .HasColumnName("f_geometry_column");
            entity.Property(e => e.CoordDimension).HasColumnName("coord_dimension");
            entity.Property(e => e.GTableCatalog)
                .HasMaxLength(32)
                .HasColumnName("g_table_catalog");
            entity.Property(e => e.GTableName)
                .HasMaxLength(128)
                .HasColumnName("g_table_name");
            entity.Property(e => e.GTableSchema)
                .HasMaxLength(32)
                .HasColumnName("g_table_schema");
            entity.Property(e => e.GeometryType).HasColumnName("geometry_type");
            entity.Property(e => e.MaxPpr).HasColumnName("max_ppr");
            entity.Property(e => e.Srid).HasColumnName("srid");
            entity.Property(e => e.StorageType).HasColumnName("storage_type");

            entity.HasOne(d => d.Sr).WithMany(p => p.SdeGeometryColumns)
                .HasForeignKey(d => d.Srid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geocol_fk");
        });

        modelBuilder.Entity<SdeLayer>(entity =>
        {
            entity.HasKey(e => new { e.DatabaseName, e.TableName, e.Owner, e.SpatialColumn }).HasName("layers_pk");

            entity.ToTable("SDE_layers");

            entity.HasIndex(e => e.LayerId, "layers_uk").IsUnique();

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(32)
                .HasColumnName("database_name");
            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.SpatialColumn)
                .HasMaxLength(32)
                .HasColumnName("spatial_column");
            entity.Property(e => e.BaseLayerId).HasColumnName("base_layer_id");
            entity.Property(e => e.Cdate).HasColumnName("cdate");
            entity.Property(e => e.Description)
                .HasMaxLength(65)
                .HasColumnName("description");
            entity.Property(e => e.Eflags).HasColumnName("eflags");
            entity.Property(e => e.Gsize1).HasColumnName("gsize1");
            entity.Property(e => e.Gsize2).HasColumnName("gsize2");
            entity.Property(e => e.Gsize3).HasColumnName("gsize3");
            entity.Property(e => e.LayerConfig)
                .HasMaxLength(32)
                .HasColumnName("layer_config");
            entity.Property(e => e.LayerId).HasColumnName("layer_id");
            entity.Property(e => e.LayerMask).HasColumnName("layer_mask");
            entity.Property(e => e.Maxm).HasColumnName("maxm");
            entity.Property(e => e.Maxx).HasColumnName("maxx");
            entity.Property(e => e.Maxy).HasColumnName("maxy");
            entity.Property(e => e.Maxz).HasColumnName("maxz");
            entity.Property(e => e.MinimumId).HasColumnName("minimum_id");
            entity.Property(e => e.Minm).HasColumnName("minm");
            entity.Property(e => e.Minx).HasColumnName("minx");
            entity.Property(e => e.Miny).HasColumnName("miny");
            entity.Property(e => e.Minz).HasColumnName("minz");
            entity.Property(e => e.OptimalArraySize).HasColumnName("optimal_array_size");
            entity.Property(e => e.SecondarySrid).HasColumnName("secondary_srid");
            entity.Property(e => e.Srid).HasColumnName("srid");
            entity.Property(e => e.StatsDate).HasColumnName("stats_date");

            entity.HasOne(d => d.SecondarySr).WithMany(p => p.SdeLayerSecondarySrs)
                .HasForeignKey(d => d.SecondarySrid)
                .HasConstraintName("layers_sfk");

            entity.HasOne(d => d.Sr).WithMany(p => p.SdeLayerSrs)
                .HasForeignKey(d => d.Srid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("layers_fk");
        });

        modelBuilder.Entity<SdeLayerLock>(entity =>
        {
            entity.HasKey(e => new { e.SdeId, e.LayerId, e.Autolock, e.LockType }).HasName("layer_locks_pk");

            entity.ToTable("SDE_layer_locks");

            entity.Property(e => e.SdeId).HasColumnName("sde_id");
            entity.Property(e => e.LayerId).HasColumnName("layer_id");
            entity.Property(e => e.Autolock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("autolock");
            entity.Property(e => e.LockType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lock_type");
            entity.Property(e => e.LockTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lock_time");
            entity.Property(e => e.Maxx).HasColumnName("maxx");
            entity.Property(e => e.Maxy).HasColumnName("maxy");
            entity.Property(e => e.Minx).HasColumnName("minx");
            entity.Property(e => e.Miny).HasColumnName("miny");
        });

        modelBuilder.Entity<SdeLayerStat>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("sdelayer_stats_pk");

            entity.ToTable("SDE_layer_stats");

            entity.HasIndex(e => new { e.LayerId, e.VersionId }, "sdelayer_stats_uk").IsUnique();

            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.LastAnalyzed)
                .HasColumnType("datetime")
                .HasColumnName("last_analyzed");
            entity.Property(e => e.LayerId).HasColumnName("layer_id");
            entity.Property(e => e.Maxm).HasColumnName("maxm");
            entity.Property(e => e.Maxx).HasColumnName("maxx");
            entity.Property(e => e.Maxy).HasColumnName("maxy");
            entity.Property(e => e.Maxz).HasColumnName("maxz");
            entity.Property(e => e.Minm).HasColumnName("minm");
            entity.Property(e => e.Minx).HasColumnName("minx");
            entity.Property(e => e.Miny).HasColumnName("miny");
            entity.Property(e => e.Minz).HasColumnName("minz");
            entity.Property(e => e.TotalFeatures).HasColumnName("total_features");
            entity.Property(e => e.TotalPoints).HasColumnName("total_points");
            entity.Property(e => e.VersionId).HasColumnName("version_id");

            entity.HasOne(d => d.Layer).WithMany(p => p.SdeLayerStats)
                .HasPrincipalKey(p => p.LayerId)
                .HasForeignKey(d => d.LayerId)
                .HasConstraintName("sdelayer_stats_fk1");

            entity.HasOne(d => d.Version).WithMany(p => p.SdeLayerStats)
                .HasForeignKey(d => d.VersionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sdelayer_stats_fk2");
        });

        modelBuilder.Entity<SdeLineagesModified>(entity =>
        {
            entity.HasKey(e => e.LineageName).HasName("lineages_mod_pk");

            entity.ToTable("SDE_lineages_modified");

            entity.Property(e => e.LineageName)
                .ValueGeneratedNever()
                .HasColumnName("lineage_name");
            entity.Property(e => e.TimeLastModified)
                .HasColumnType("datetime")
                .HasColumnName("time_last_modified");
        });

        modelBuilder.Entity<SdeLocator>(entity =>
        {
            entity.HasKey(e => e.LocatorId).HasName("sdelocators_pk");

            entity.ToTable("SDE_locators");

            entity.HasIndex(e => new { e.Name, e.Owner }, "sdelocators_uk").IsUnique();

            entity.Property(e => e.LocatorId)
                .ValueGeneratedNever()
                .HasColumnName("locator_id");
            entity.Property(e => e.Category)
                .HasMaxLength(32)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<SdeLogfilePool>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("logfile_pool_pk");

            entity.ToTable("SDE_logfile_pool");

            entity.Property(e => e.TableId)
                .ValueGeneratedNever()
                .HasColumnName("table_id");
            entity.Property(e => e.SdeId).HasColumnName("sde_id");
        });

        modelBuilder.Entity<SdeMetadatum>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("sdemetadata_pk");

            entity.ToTable("SDE_metadata");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(32)
                .HasColumnName("class_name");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.Description)
                .HasMaxLength(65)
                .HasColumnName("description");
            entity.Property(e => e.ObjectDatabase)
                .HasMaxLength(32)
                .HasColumnName("object_database");
            entity.Property(e => e.ObjectName)
                .HasMaxLength(160)
                .HasColumnName("object_name");
            entity.Property(e => e.ObjectOwner)
                .HasMaxLength(32)
                .HasColumnName("object_owner");
            entity.Property(e => e.ObjectType).HasColumnName("object_type");
            entity.Property(e => e.PropValue)
                .HasMaxLength(255)
                .HasColumnName("prop_value");
            entity.Property(e => e.Property)
                .HasMaxLength(32)
                .HasColumnName("property");
        });

        modelBuilder.Entity<SdeObjectId>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("object_ids_pk");

            entity.ToTable("SDE_object_ids");

            entity.Property(e => e.IdType)
                .ValueGeneratedNever()
                .HasColumnName("id_type");
            entity.Property(e => e.BaseId).HasColumnName("base_id");
            entity.Property(e => e.ObjectType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("object_type");
        });

        modelBuilder.Entity<SdeObjectLock>(entity =>
        {
            entity.HasKey(e => new { e.SdeId, e.ObjectId, e.ObjectType, e.ApplicationId, e.Autolock, e.LockType }).HasName("object_locks_pk");

            entity.ToTable("SDE_object_locks");

            entity.Property(e => e.SdeId).HasColumnName("sde_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectType).HasColumnName("object_type");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.Autolock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("autolock");
            entity.Property(e => e.LockType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lock_type");
            entity.Property(e => e.LockTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lock_time");
        });

        modelBuilder.Entity<SdeProcessInformation>(entity =>
        {
            entity.HasKey(e => e.SdeId).HasName("process_pk");

            entity.ToTable("SDE_process_information");

            entity.Property(e => e.SdeId)
                .ValueGeneratedNever()
                .HasColumnName("sde_id");
            entity.Property(e => e.DirectConnect)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("direct_connect");
            entity.Property(e => e.FbCount).HasColumnName("fb_count");
            entity.Property(e => e.FbFcount).HasColumnName("fb_fcount");
            entity.Property(e => e.FbKbytes).HasColumnName("fb_kbytes");
            entity.Property(e => e.FbPartial).HasColumnName("fb_partial");
            entity.Property(e => e.Nodename)
                .HasMaxLength(256)
                .HasColumnName("nodename");
            entity.Property(e => e.Numlocks).HasColumnName("numlocks");
            entity.Property(e => e.Opcount).HasColumnName("opcount");
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .HasColumnName("owner");
            entity.Property(e => e.Rcount).HasColumnName("rcount");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.Spid).HasColumnName("spid");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Sysname)
                .HasMaxLength(32)
                .HasColumnName("sysname");
            entity.Property(e => e.TableName)
                .HasMaxLength(95)
                .HasColumnName("table_name");
            entity.Property(e => e.Wcount).HasColumnName("wcount");
            entity.Property(e => e.XdrNeeded)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("xdr_needed");
        });

        modelBuilder.Entity<SdeRasterColumn>(entity =>
        {
            entity.HasKey(e => new { e.DatabaseName, e.Owner, e.TableName, e.RasterColumn }).HasName("rascol_pk");

            entity.ToTable("SDE_raster_columns");

            entity.HasIndex(e => e.RastercolumnId, "rascol_uk").IsUnique();

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(32)
                .HasColumnName("database_name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
            entity.Property(e => e.RasterColumn)
                .HasMaxLength(32)
                .HasColumnName("raster_column");
            entity.Property(e => e.BaseRastercolumnId).HasColumnName("base_rastercolumn_id");
            entity.Property(e => e.Cdate).HasColumnName("cdate");
            entity.Property(e => e.ConfigKeyword)
                .HasMaxLength(32)
                .HasColumnName("config_keyword");
            entity.Property(e => e.Description)
                .HasMaxLength(65)
                .HasColumnName("description");
            entity.Property(e => e.MinimumId).HasColumnName("minimum_id");
            entity.Property(e => e.RastercolumnId).HasColumnName("rastercolumn_id");
            entity.Property(e => e.RastercolumnMask).HasColumnName("rastercolumn_mask");
            entity.Property(e => e.Srid).HasColumnName("srid");

            entity.HasOne(d => d.Sr).WithMany(p => p.SdeRasterColumns)
                .HasForeignKey(d => d.Srid)
                .HasConstraintName("rascol_fk");
        });

        modelBuilder.Entity<SdeServerConfig>(entity =>
        {
            entity.HasKey(e => e.PropName).HasName("server_config_pk");

            entity.ToTable("SDE_server_config");

            entity.Property(e => e.PropName)
                .HasMaxLength(32)
                .HasColumnName("prop_name");
            entity.Property(e => e.CharPropValue)
                .HasMaxLength(512)
                .HasColumnName("char_prop_value");
            entity.Property(e => e.NumPropValue).HasColumnName("num_prop_value");
        });

        modelBuilder.Entity<SdeSpatialReference>(entity =>
        {
            entity.HasKey(e => e.Srid).HasName("spatial_ref_pk");

            entity.ToTable("SDE_spatial_references");

            entity.Property(e => e.Srid)
                .ValueGeneratedNever()
                .HasColumnName("srid");
            entity.Property(e => e.AuthName)
                .HasMaxLength(255)
                .HasColumnName("auth_name");
            entity.Property(e => e.AuthSrid).HasColumnName("auth_srid");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.Falsem).HasColumnName("falsem");
            entity.Property(e => e.Falsex).HasColumnName("falsex");
            entity.Property(e => e.Falsey).HasColumnName("falsey");
            entity.Property(e => e.Falsez).HasColumnName("falsez");
            entity.Property(e => e.MclusterTol).HasColumnName("mcluster_tol");
            entity.Property(e => e.Munits).HasColumnName("munits");
            entity.Property(e => e.ObjectFlags).HasColumnName("object_flags");
            entity.Property(e => e.Srtext)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("srtext");
            entity.Property(e => e.XyclusterTol).HasColumnName("xycluster_tol");
            entity.Property(e => e.Xyunits).HasColumnName("xyunits");
            entity.Property(e => e.ZclusterTol).HasColumnName("zcluster_tol");
            entity.Property(e => e.Zunits).HasColumnName("zunits");
        });

        modelBuilder.Entity<SdeState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("states_pk");

            entity.ToTable("SDE_states", tb => tb.HasTrigger("sde_lineage_delete"));

            entity.HasIndex(e => new { e.ParentStateId, e.LineageName }, "states_cuk").IsUnique();

            entity.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("state_id");
            entity.Property(e => e.ClosingTime)
                .HasColumnType("datetime")
                .HasColumnName("closing_time");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.LineageName).HasColumnName("lineage_name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.ParentStateId).HasColumnName("parent_state_id");

            entity.HasMany(d => d.Registrations).WithMany(p => p.States)
                .UsingEntity<Dictionary<string, object>>(
                    "SdeMvtablesModified",
                    r => r.HasOne<SdeTableRegistry>().WithMany()
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("mvtables_modified_fk2"),
                    l => l.HasOne<SdeState>().WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("mvtables_modified_fk1"),
                    j =>
                    {
                        j.HasKey("StateId", "RegistrationId").HasName("mvtables_modified_pk");
                        j.ToTable("SDE_mvtables_modified");
                        j.IndexerProperty<long>("StateId").HasColumnName("state_id");
                        j.IndexerProperty<int>("RegistrationId").HasColumnName("registration_id");
                    });
        });

        modelBuilder.Entity<SdeStateLineage>(entity =>
        {
            entity.HasKey(e => new { e.LineageName, e.LineageId }).HasName("state_lineages_pk");

            entity.ToTable("SDE_state_lineages");

            entity.HasIndex(e => e.LineageId, "lineage_id_idx2").HasFillFactor(75);

            entity.Property(e => e.LineageName).HasColumnName("lineage_name");
            entity.Property(e => e.LineageId).HasColumnName("lineage_id");
        });

        modelBuilder.Entity<SdeStateLock>(entity =>
        {
            entity.HasKey(e => new { e.SdeId, e.StateId, e.Autolock, e.LockType }).HasName("state_locks_pk");

            entity.ToTable("SDE_state_locks");

            entity.Property(e => e.SdeId).HasColumnName("sde_id");
            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.Autolock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("autolock");
            entity.Property(e => e.LockType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lock_type");
            entity.Property(e => e.LockTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lock_time");
        });

        modelBuilder.Entity<SdeTableLock>(entity =>
        {
            entity.HasKey(e => new { e.SdeId, e.RegistrationId, e.LockType }).HasName("table_locks_pk");

            entity.ToTable("SDE_table_locks");

            entity.Property(e => e.SdeId).HasColumnName("sde_id");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.LockType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("lock_type");
            entity.Property(e => e.LockTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lock_time");
        });

        modelBuilder.Entity<SdeTableRegistry>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("registry_pk");

            entity.ToTable("SDE_table_registry");

            entity.HasIndex(e => new { e.TableName, e.Owner, e.DatabaseName }, "registry_uk2").IsUnique();

            entity.Property(e => e.RegistrationId)
                .ValueGeneratedNever()
                .HasColumnName("registration_id");
            entity.Property(e => e.ConfigKeyword)
                .HasMaxLength(32)
                .HasColumnName("config_keyword");
            entity.Property(e => e.DatabaseName)
                .HasMaxLength(32)
                .HasColumnName("database_name");
            entity.Property(e => e.Description)
                .HasMaxLength(65)
                .HasColumnName("description");
            entity.Property(e => e.ImvViewName)
                .HasMaxLength(128)
                .HasColumnName("imv_view_name");
            entity.Property(e => e.MinimumId).HasColumnName("minimum_id");
            entity.Property(e => e.ObjectFlags).HasColumnName("object_flags");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.RowidColumn)
                .HasMaxLength(32)
                .HasColumnName("rowid_column");
            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
        });

        modelBuilder.Entity<SdeTablesModified>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("tables_modified_pk");

            entity.ToTable("SDE_tables_modified");

            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
            entity.Property(e => e.TimeLastModified)
                .HasColumnType("datetime")
                .HasColumnName("time_last_modified");
        });

        modelBuilder.Entity<SdeVersion>(entity =>
        {
            entity.HasKey(e => e.Major).HasName("version_pk");

            entity.ToTable("SDE_version");

            entity.Property(e => e.Major)
                .ValueGeneratedNever()
                .HasColumnName("MAJOR");
            entity.Property(e => e.Bugfix).HasColumnName("BUGFIX");
            entity.Property(e => e.Description)
                .HasMaxLength(96)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Minor).HasColumnName("MINOR");
            entity.Property(e => e.Release).HasColumnName("RELEASE");
            entity.Property(e => e.SdesvrRelLow).HasColumnName("SDESVR_REL_LOW");
        });

        modelBuilder.Entity<SdeVersion1>(entity =>
        {
            entity.HasKey(e => e.VersionId).HasName("versions_pk");

            entity.ToTable("SDE_versions");

            entity.HasIndex(e => new { e.Name, e.Owner }, "versions_uk").IsUnique();

            entity.Property(e => e.VersionId)
                .ValueGeneratedNever()
                .HasColumnName("version_id");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("creation_time");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
            entity.Property(e => e.ParentName)
                .HasMaxLength(64)
                .HasColumnName("parent_name");
            entity.Property(e => e.ParentOwner)
                .HasMaxLength(32)
                .HasColumnName("parent_owner");
            entity.Property(e => e.ParentVersionId).HasColumnName("parent_version_id");
            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<SdeXmlColumn>(entity =>
        {
            entity.HasKey(e => e.ColumnId)
                .HasName("xml_columns_pk")
                .IsClustered(false);

            entity.ToTable("SDE_xml_columns");

            entity.HasIndex(e => new { e.RegistrationId, e.ColumnName }, "xml_columns_uk")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.ColumnId).HasColumnName("column_id");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(32)
                .HasColumnName("column_name");
            entity.Property(e => e.ConfigKeyword)
                .HasMaxLength(32)
                .HasColumnName("config_keyword");
            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.MinimumId).HasColumnName("minimum_id");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.Xflags).HasColumnName("xflags");

            entity.HasOne(d => d.Index).WithMany(p => p.SdeXmlColumns)
                .HasForeignKey(d => d.IndexId)
                .HasConstraintName("xml_columns_fk2");

            entity.HasOne(d => d.Registration).WithMany(p => p.SdeXmlColumns)
                .HasForeignKey(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("xml_columns_fk1");
        });

        modelBuilder.Entity<SdeXmlIndex>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("xml_indexes_pk");

            entity.ToTable("SDE_xml_indexes");

            entity.HasIndex(e => new { e.Owner, e.IndexName }, "xml_indexes_uk").IsUnique();

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.IndexName)
                .HasMaxLength(32)
                .HasColumnName("index_name");
            entity.Property(e => e.IndexType).HasColumnName("index_type");
            entity.Property(e => e.Owner)
                .HasMaxLength(32)
                .HasColumnName("owner");
        });

        modelBuilder.Entity<SdeXmlIndexTag>(entity =>
        {
            entity.HasKey(e => new { e.IndexId, e.TagId }).HasName("xml_indextags_pk");

            entity.ToTable("SDE_xml_index_tags");

            entity.HasIndex(e => e.TagName, "xml_indextags_ix1");

            entity.HasIndex(e => e.TagAlias, "xml_indextags_ix2");

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.TagId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tag_id");
            entity.Property(e => e.DataType).HasColumnName("data_type");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.IsExcluded).HasColumnName("is_excluded");
            entity.Property(e => e.TagAlias).HasColumnName("tag_alias");
            entity.Property(e => e.TagName)
                .HasMaxLength(1024)
                .HasColumnName("tag_name");

            entity.HasOne(d => d.Index).WithMany(p => p.SdeXmlIndexTags)
                .HasForeignKey(d => d.IndexId)
                .HasConstraintName("xml_indextags_fk1");
        });

        modelBuilder.Entity<StGeometryColumn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ST_GEOMETRY_COLUMNS");

            entity.Property(e => e.ColumnName)
                .HasMaxLength(32)
                .HasColumnName("column_name");
            entity.Property(e => e.SrsId).HasColumnName("srs_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(128)
                .HasColumnName("table_name");
            entity.Property(e => e.TableSchema)
                .HasMaxLength(32)
                .HasColumnName("table_schema");
            entity.Property(e => e.TypeName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("type_name");
            entity.Property(e => e.TypeSchema)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("type_schema");
        });

        modelBuilder.Entity<StSpatialReferenceSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ST_SPATIAL_REFERENCE_SYSTEMS");

            entity.Property(e => e.Definition)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("definition");
            entity.Property(e => e.MOffset).HasColumnName("m_offset");
            entity.Property(e => e.MScale).HasColumnName("m_scale");
            entity.Property(e => e.Organization)
                .HasMaxLength(255)
                .HasColumnName("organization");
            entity.Property(e => e.OrganizationCoordsysId).HasColumnName("organization_coordsys_id");
            entity.Property(e => e.SrsId).HasColumnName("srs_id");
            entity.Property(e => e.XOffset).HasColumnName("x_offset");
            entity.Property(e => e.XScale).HasColumnName("x_scale");
            entity.Property(e => e.YOffset).HasColumnName("y_offset");
            entity.Property(e => e.YScale).HasColumnName("y_scale");
            entity.Property(e => e.ZOffset).HasColumnName("z_offset");
            entity.Property(e => e.ZScale).HasColumnName("z_scale");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
