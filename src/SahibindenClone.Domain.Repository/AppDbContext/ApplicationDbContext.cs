using Microsoft.EntityFrameworkCore;
using SahibindenClone.Domain.Entities;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Repository.AppDbContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PropertyDefinition> PropertyDefinitions { get; set; }
    public DbSet<Listing> Listings { get; set; }
    public DbSet<ListingProperty> ListingProperties { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<SavedSearch> SavedSearches { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<UserPackage> UserPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global Query Filters - Soft Delete
        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Listing>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Report>().HasQueryFilter(e => !e.IsDeleted);

        // User Configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Phone).IsUnique();
            entity.HasIndex(e => e.UserType);
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.CreatedAt);

            entity.Property(e => e.UserType)
                .HasConversion<int>();

            entity.Property(e => e.Status)
                .HasConversion<int>();

            entity.Property(e => e.EmailVerificationStatus)
                .HasConversion<int>();

            entity.Property(e => e.PhoneVerificationStatus)
                .HasConversion<int>();

            entity.HasMany(e => e.Listings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Favorites)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.SentMessages)
                .WithOne(e => e.Sender)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.ReceivedMessages)
                .WithOne(e => e.Receiver)
                .HasForeignKey(e => e.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.SavedSearches)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Reports)
                .WithOne(e => e.Reporter)
                .HasForeignKey(e => e.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Category Configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasIndex(e => new { e.ParentId, e.Order });
            entity.HasIndex(e => e.IsActive);

            entity.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.PropertyDefinitions)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // PropertyDefinition Configuration
        modelBuilder.Entity<PropertyDefinition>(entity =>
        {
            entity.HasIndex(e => new { e.CategoryId, e.Key }).IsUnique();
            entity.HasIndex(e => new { e.CategoryId, e.Order });

            entity.Property(e => e.DataType)
                .HasConversion<int>();

            entity.Property(e => e.InputType)
                .HasConversion<int>();
        });

        // Listing Configuration
        modelBuilder.Entity<Listing>(entity =>
        {
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.CreatedAt);
            entity.HasIndex(e => e.PublishedAt);
            entity.HasIndex(e => e.CategoryId);
            entity.HasIndex(e => e.LocationId);
            entity.HasIndex(e => e.Price);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.ListingCode).IsUnique();
            entity.HasIndex(e => new { e.IsFeatured, e.CreatedAt });
            entity.HasIndex(e => new { e.Status, e.CreatedAt });

            entity.Property(e => e.Status)
                .HasConversion<int>();

            entity.Property(e => e.Currency)
                .HasConversion<int>();

            entity.HasMany(e => e.Properties)
                .WithOne(e => e.Listing)
                .HasForeignKey(e => e.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Images)
                .WithOne(e => e.Listing)
                .HasForeignKey(e => e.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Favorites)
                .WithOne(e => e.Listing)
                .HasForeignKey(e => e.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Messages)
                .WithOne(e => e.Listing)
                .HasForeignKey(e => e.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Reports)
                .WithOne(e => e.Listing)
                .HasForeignKey(e => e.ListingId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ListingProperty Configuration
        modelBuilder.Entity<ListingProperty>(entity =>
        {
            entity.HasIndex(e => new { e.ListingId, e.PropertyDefinitionId }).IsUnique();
            entity.HasIndex(e => e.ValueNumeric);
            entity.HasIndex(e => e.ValueBoolean);
            entity.HasIndex(e => e.ValueDate);
        });

        // Location Configuration
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.HasIndex(e => new { e.ParentId, e.Level });
            entity.HasIndex(e => e.Level);

            entity.Property(e => e.Level)
                .HasConversion<int>();

            entity.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Image Configuration
        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasIndex(e => new { e.ListingId, e.Order });
            entity.HasIndex(e => new { e.ListingId, e.IsPrimary });

            entity.Property(e => e.ImageType)
                .HasConversion<int>();
        });

        // Favorite Configuration
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasIndex(e => new { e.UserId, e.ListingId }).IsUnique();
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.CreatedAt);
        });

        // Message Configuration
        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasIndex(e => e.SenderId);
            entity.HasIndex(e => e.ReceiverId);
            entity.HasIndex(e => e.ListingId);
            entity.HasIndex(e => e.CreatedAt);
            entity.HasIndex(e => new { e.ReceiverId, e.Status });

            entity.Property(e => e.Status)
                .HasConversion<int>();
        });

        // SavedSearch Configuration
        modelBuilder.Entity<SavedSearch>(entity =>
        {
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => new { e.UserId, e.IsActive });

            entity.Property(e => e.NotificationFrequency)
                .HasConversion<int>();
        });

        // Report Configuration
        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasIndex(e => e.ListingId);
            entity.HasIndex(e => e.ReporterId);
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => new { e.Status, e.CreatedAt });

            entity.Property(e => e.ReportType)
                .HasConversion<int>();

            entity.Property(e => e.Status)
                .HasConversion<int>();
        });

        // Package Configuration
        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasIndex(e => e.PackageType);
            entity.HasIndex(e => e.IsActive);

            entity.Property(e => e.PackageType)
                .HasConversion<int>();

            entity.Property(e => e.Currency)
                .HasConversion<int>();
        });

        // UserPackage Configuration
        modelBuilder.Entity<UserPackage>(entity =>
        {
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.ListingId);
            entity.HasIndex(e => new { e.IsActive, e.EndDate });
            entity.HasIndex(e => new { e.UserId, e.IsActive });

            entity.Property(e => e.PaymentStatus)
                .HasConversion<int>();
        });

        // Seed Data
        SeedData(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            entity.UpdatedAt = DateTime.UtcNow;

            // Soft Delete için
            if (entity is AuditableEntity auditableEntity && auditableEntity.IsDeleted)
            {
                auditableEntity.DeletedAt = DateTime.UtcNow;
            }
        }
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Kategoriler
        var emlakId = Guid.NewGuid();
        var vasitaId = Guid.NewGuid();
        var daireSatilikId = Guid.NewGuid();
        var otomobilId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = emlakId,
                Name = "Emlak",
                Slug = "emlak",
                Icon = "building",
                IsActive = true,
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = vasitaId,
                Name = "Vasıta",
                Slug = "vasita",
                Icon = "car",
                IsActive = true,
                Order = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = daireSatilikId,
                Name = "Satılık Daire",
                Slug = "satilik-daire",
                ParentId = emlakId,
                IsActive = true,
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Category
            {
                Id = otomobilId,
                Name = "Otomobil",
                Slug = "otomobil",
                ParentId = vasitaId,
                IsActive = true,
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        // Property Definitions - Emlak
        modelBuilder.Entity<PropertyDefinition>().HasData(
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = daireSatilikId,
                Name = "Metrekare (Brüt)",
                Key = "square_meter",
                DataType = PropertyDataType.Number,
                InputType = InputType.Number,
                IsRequired = true,
                IsFilterable = true,
                IsSearchable = false,
                Unit = "m²",
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = daireSatilikId,
                Name = "Oda Sayısı",
                Key = "room_count",
                DataType = PropertyDataType.Select,
                InputType = InputType.Dropdown,
                IsRequired = true,
                IsFilterable = true,
                IsSearchable = false,
                Options = "[\"1+0\",\"1+1\",\"2+1\",\"3+1\",\"4+1\",\"5+1\"]",
                Order = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = daireSatilikId,
                Name = "Bina Yaşı",
                Key = "building_age",
                DataType = PropertyDataType.Select,
                InputType = InputType.Dropdown,
                IsRequired = false,
                IsFilterable = true,
                IsSearchable = false,
                Options = "[\"0\",\"1-5\",\"6-10\",\"11-15\",\"16-20\",\"21+\"]",
                Order = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        // Property Definitions - Vasıta
        modelBuilder.Entity<PropertyDefinition>().HasData(
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = otomobilId,
                Name = "Kilometre",
                Key = "kilometer",
                DataType = PropertyDataType.Number,
                InputType = InputType.Number,
                IsRequired = true,
                IsFilterable = true,
                IsSearchable = false,
                Unit = "km",
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = otomobilId,
                Name = "Yıl",
                Key = "year",
                DataType = PropertyDataType.Number,
                InputType = InputType.Number,
                IsRequired = true,
                IsFilterable = true,
                IsSearchable = false,
                Order = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new PropertyDefinition
            {
                Id = Guid.NewGuid(),
                CategoryId = otomobilId,
                Name = "Yakıt Tipi",
                Key = "fuel_type",
                DataType = PropertyDataType.Select,
                InputType = InputType.Dropdown,
                IsRequired = true,
                IsFilterable = true,
                IsSearchable = false,
                Options = "[\"Benzin\",\"Dizel\",\"LPG\",\"Elektrik\",\"Hybrid\"]",
                Order = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}