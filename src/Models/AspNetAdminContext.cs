using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace asp_net_admin.Models;

public partial class AspNetAdminContext : DbContext
{
    public AspNetAdminContext()
    {
    }

    public AspNetAdminContext(DbContextOptions<AspNetAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnaTicket> AnaTickets { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<AnnouncementUser> AnnouncementUsers { get; set; }

    public virtual DbSet<ApiKey> ApiKeys { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ConvertStatus> ConvertStatuses { get; set; }

    public virtual DbSet<ConvertedVideo> ConvertedVideos { get; set; }

    public virtual DbSet<CoopInfo> CoopInfos { get; set; }

    public virtual DbSet<DataRow> DataRows { get; set; }

    public virtual DbSet<DataType> DataTypes { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<ImageFile> ImageFiles { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionItem> SubscriptionItems { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<ThemeOption> ThemeOptions { get; set; }

    public virtual DbSet<Translation> Translations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserConfig> UserConfigs { get; set; }

    public virtual DbSet<UserViewGroupMp> UserViewGroupMps { get; set; }

    public virtual DbSet<UserViewMp> UserViewMps { get; set; }

    public virtual DbSet<UserViewTotal> UserViewTotals { get; set; }

    public virtual DbSet<VideoCategory> VideoCategories { get; set; }

    public virtual DbSet<VideoFile> VideoFiles { get; set; }

    public virtual DbSet<VideoGroup> VideoGroups { get; set; }

    public virtual DbSet<VideoGroupVideoProject> VideoGroupVideoProjects { get; set; }

    public virtual DbSet<VideoOption> VideoOptions { get; set; }

    public virtual DbSet<VideoProject> VideoProjects { get; set; }

    public virtual DbSet<VideoProjectOptionImageFile> VideoProjectOptionImageFiles { get; set; }

    public virtual DbSet<VideoType> VideoTypes { get; set; }

    public virtual DbSet<VideoUnit> VideoUnits { get; set; }

    public virtual DbSet<VideoUnitsVideoFile> VideoUnitsVideoFiles { get; set; }

    public virtual DbSet<WaveKeyValue> WaveKeyValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=asp_net_admin;Uid=dbuser;Pwd=dbpassword;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnaTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ana_ticket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DataAddAt)
                .HasComment("データ登録時間")
                .HasColumnType("datetime")
                .HasColumnName("data_add_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Message)
                .HasComment("エラーメッセージ等")
                .HasColumnName("message");
            entity.Property(e => e.Passcode)
                .HasColumnType("text")
                .HasColumnName("passcode");
            entity.Property(e => e.ResultAt)
                .HasComment("画像解析完了時間")
                .HasColumnType("datetime")
                .HasColumnName("result_at");
            entity.Property(e => e.ResultJson)
                .HasComment("OCR 解析した結果の JSON情報")
                .HasColumnName("result_json");
            entity.Property(e => e.S3Filename)
                .HasComment("S3 に登録したファイル名")
                .HasColumnType("text")
                .HasColumnName("s3_filename");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("announcements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AnnouncementUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("announcement_user");

            entity.HasIndex(e => e.AnnouncementId, "announcement_user_announcement_id_index");

            entity.HasIndex(e => e.UserId, "announcement_user_user_id_index");

            entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Announcement).WithMany()
                .HasForeignKey(d => d.AnnouncementId)
                .HasConstraintName("announcement_user_announcement_id_foreign");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("announcement_user_user_id_foreign");
        });

        modelBuilder.Entity<ApiKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("api_keys");

            entity.HasIndex(e => e.Key, "api_tokens_token_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Key)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .HasColumnName("key");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_used_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasColumnType("datetime");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PRIMARY");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PRIMARY");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.ParentId, "categories_parent_id_foreign");

            entity.HasIndex(e => e.Slug, "categories_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("categories_parent_id_foreign");
        });

        modelBuilder.Entity<ConvertStatus>(entity =>
        {
            entity.HasKey(e => e.Status).HasName("PRIMARY");

            entity.ToTable("convert_statuses");

            entity.Property(e => e.Status)
                .HasMaxLength(191)
                .HasColumnName("status");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ConvertedVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("converted_videos");

            entity.HasIndex(e => e.AuthorId, "converted_videos_author_id_foreign");

            entity.HasIndex(e => e.JobHigh, "converted_videos_job_high_unique").IsUnique();

            entity.HasIndex(e => e.JobLow, "converted_videos_job_low_unique").IsUnique();

            entity.HasIndex(e => e.Status, "converted_videos_status_foreign");

            entity.HasIndex(e => e.Type, "converted_videos_type_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.ConvertHighTime)
                .HasColumnType("datetime")
                .HasColumnName("convert_high_time");
            entity.Property(e => e.ConvertLowTime)
                .HasColumnType("datetime")
                .HasColumnName("convert_low_time");
            entity.Property(e => e.ConvertStartTime)
                .HasColumnType("datetime")
                .HasColumnName("convert_start_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Dirpath)
                .HasMaxLength(191)
                .HasComment("動画のS3上のパス")
                .HasColumnName("dirpath");
            entity.Property(e => e.JobHigh)
                .HasMaxLength(32)
                .HasColumnName("job_high");
            entity.Property(e => e.JobLow)
                .HasMaxLength(32)
                .HasColumnName("job_low");
            entity.Property(e => e.Status)
                .HasMaxLength(191)
                .HasComment("動画のエンコード状態")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasComment("動画のエンコード形式")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Author).WithMany(p => p.ConvertedVideos)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("converted_videos_author_id_foreign");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.ConvertedVideos)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("converted_videos_status_foreign");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.ConvertedVideos)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("converted_videos_type_foreign");
        });

        modelBuilder.Entity<CoopInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coop_info");

            entity.HasIndex(e => e.Name, "coop_info_name_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.LoginHtmlFooter)
                .HasComment("フッター表示 HTML")
                .HasColumnName("login_html_footer");
            entity.Property(e => e.LoginHtmlHeader)
                .HasComment("ヘッダー表示 HTML")
                .HasColumnName("login_html_header");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasComment("名称")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DataRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("data_rows");

            entity.HasIndex(e => e.DataTypeId, "data_rows_data_type_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Add)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("add");
            entity.Property(e => e.Browse)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("browse");
            entity.Property(e => e.DataTypeId).HasColumnName("data_type_id");
            entity.Property(e => e.Delete)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("delete");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(191)
                .HasColumnName("display_name");
            entity.Property(e => e.Edit)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("edit");
            entity.Property(e => e.Field)
                .HasMaxLength(191)
                .HasColumnName("field");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.Read)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("read");
            entity.Property(e => e.Required).HasColumnName("required");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");

            entity.HasOne(d => d.DataType).WithMany(p => p.DataRows)
                .HasForeignKey(d => d.DataTypeId)
                .HasConstraintName("data_rows_data_type_id_foreign");
        });

        modelBuilder.Entity<DataType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("data_types");

            entity.HasIndex(e => e.Name, "data_types_name_unique").IsUnique();

            entity.HasIndex(e => e.Slug, "data_types_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Controller)
                .HasMaxLength(191)
                .HasColumnName("controller");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasColumnName("description");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayNamePlural)
                .HasMaxLength(191)
                .HasColumnName("display_name_plural");
            entity.Property(e => e.DisplayNameSingular)
                .HasMaxLength(191)
                .HasColumnName("display_name_singular");
            entity.Property(e => e.GeneratePermissions).HasColumnName("generate_permissions");
            entity.Property(e => e.Icon)
                .HasMaxLength(191)
                .HasColumnName("icon");
            entity.Property(e => e.ModelName)
                .HasMaxLength(191)
                .HasColumnName("model_name");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.PolicyName)
                .HasMaxLength(191)
                .HasColumnName("policy_name");
            entity.Property(e => e.ServerSide).HasColumnName("server_side");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<ImageFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("image_files");

            entity.HasIndex(e => e.AuthorId, "image_files_author_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Filename)
                .HasMaxLength(191)
                .HasComment("元々の名前")
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasMaxLength(191)
                .HasComment("画像のS3上のパス　拡張子を含めたフルパス")
                .HasColumnName("filepath");
            entity.Property(e => e.Filesize).HasColumnName("filesize");
            entity.Property(e => e.Height)
                .HasComment("画像の縦幅px")
                .HasColumnName("height");
            entity.Property(e => e.OwnerProjectId).HasColumnName("owner_project_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VerNo).HasColumnName("ver_no");
            entity.Property(e => e.Width)
                .HasComment("画像の横幅px")
                .HasColumnName("width");

            entity.HasOne(d => d.Author).WithMany(p => p.ImageFiles)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("image_files_author_id_foreign");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menus");

            entity.HasIndex(e => e.Name, "menus_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu_items");

            entity.HasIndex(e => e.MenuId, "menu_items_menu_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(191)
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.IconClass)
                .HasMaxLength(191)
                .HasColumnName("icon_class");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Parameters)
                .HasColumnType("text")
                .HasColumnName("parameters");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Route)
                .HasMaxLength(191)
                .HasColumnName("route");
            entity.Property(e => e.Target)
                .HasMaxLength(191)
                .HasDefaultValueSql("'_self'")
                .HasColumnName("target");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasMaxLength(191)
                .HasColumnName("url");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("menu_items_menu_id_foreign");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(191)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notifications");

            entity.HasIndex(e => new { e.NotifiableId, e.NotifiableType }, "notifications_notifiable_id_notifiable_type_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.NotifiableId).HasColumnName("notifiable_id");
            entity.Property(e => e.NotifiableType)
                .HasMaxLength(191)
                .HasColumnName("notifiable_type");
            entity.Property(e => e.ReadAt)
                .HasColumnType("datetime")
                .HasColumnName("read_at");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pages");

            entity.HasIndex(e => e.Slug, "pages_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Excerpt)
                .HasColumnType("text")
                .HasColumnName("excerpt");
            entity.Property(e => e.Image)
                .HasMaxLength(191)
                .HasColumnName("image");
            entity.Property(e => e.MetaDescription)
                .HasColumnType("text")
                .HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords)
                .HasColumnType("text")
                .HasColumnName("meta_keywords");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'INACTIVE'")
                .HasColumnType("enum('ACTIVE','INACTIVE')")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("password_resets");

            entity.HasIndex(e => e.Email, "password_resets_email_index");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.Token)
                .HasMaxLength(191)
                .HasColumnName("token");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permissions");

            entity.HasIndex(e => e.Key, "permissions_key_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.PermissionGroupId).HasColumnName("permission_group_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(191)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasMany(d => d.Roles).WithMany(p => p.Permissions)
                .UsingEntity<Dictionary<string, object>>(
                    "PermissionRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("permission_role_role_id_foreign"),
                    l => l.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("permission_role_permission_id_foreign"),
                    j =>
                    {
                        j.HasKey("PermissionId", "RoleId").HasName("PRIMARY");
                        j.ToTable("permission_role");
                        j.HasIndex(new[] { "PermissionId" }, "permission_role_permission_id_index");
                        j.HasIndex(new[] { "RoleId" }, "permission_role_role_id_index");
                        j.IndexerProperty<ulong>("PermissionId").HasColumnName("permission_id");
                        j.IndexerProperty<ulong>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<PermissionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permission_groups");

            entity.HasIndex(e => e.Name, "permission_groups_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("plans");

            entity.HasIndex(e => e.RoleId, "plans_role_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Default).HasColumnName("default");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Features)
                .HasMaxLength(191)
                .HasColumnName("features");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.PlanId)
                .HasMaxLength(191)
                .HasDefaultValueSql("''")
                .HasColumnName("plan_id");
            entity.Property(e => e.Price)
                .HasMaxLength(191)
                .HasColumnName("price");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.TrialDays).HasColumnName("trial_days");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Role).WithMany(p => p.Plans)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("plans_role_id_foreign");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.HasIndex(e => e.Slug, "posts_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Excerpt)
                .HasColumnType("text")
                .HasColumnName("excerpt");
            entity.Property(e => e.Featured).HasColumnName("featured");
            entity.Property(e => e.Image)
                .HasMaxLength(191)
                .HasColumnName("image");
            entity.Property(e => e.MetaDescription)
                .HasColumnType("text")
                .HasColumnName("meta_description");
            entity.Property(e => e.MetaKeywords)
                .HasColumnType("text")
                .HasColumnName("meta_keywords");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(191)
                .HasColumnName("seo_title");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'DRAFT'")
                .HasColumnType("enum('PUBLISHED','DRAFT','PENDING')")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "roles_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(191)
                .HasColumnName("display_name");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("settings");

            entity.HasIndex(e => e.Key, "settings_key_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Details)
                .HasColumnType("text")
                .HasColumnName("details");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(191)
                .HasColumnName("display_name");
            entity.Property(e => e.Group)
                .HasMaxLength(191)
                .HasColumnName("group");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'1'")
                .HasColumnName("order");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscriptions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EndsAt)
                .HasColumnType("datetime")
                .HasColumnName("ends_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StripeId)
                .HasMaxLength(191)
                .HasColumnName("stripe_id");
            entity.Property(e => e.StripePlan)
                .HasMaxLength(191)
                .HasColumnName("stripe_plan");
            entity.Property(e => e.StripeStatus)
                .HasMaxLength(191)
                .HasColumnName("stripe_status");
            entity.Property(e => e.TrialEndsAt)
                .HasColumnType("datetime")
                .HasColumnName("trial_ends_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<SubscriptionItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subscription_items");

            entity.HasIndex(e => e.StripeId, "subscription_items_stripe_id_index");

            entity.HasIndex(e => new { e.SubscriptionId, e.StripePlan }, "subscription_items_subscription_id_stripe_plan_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StripeId)
                .HasMaxLength(191)
                .HasColumnName("stripe_id");
            entity.Property(e => e.StripePlan)
                .HasMaxLength(191)
                .HasColumnName("stripe_plan");
            entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("themes");

            entity.HasIndex(e => e.Folder, "voyager_themes_folder_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Folder)
                .HasMaxLength(191)
                .HasColumnName("folder");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasDefaultValueSql("''")
                .HasColumnName("version");
        });

        modelBuilder.Entity<ThemeOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("theme_options");

            entity.HasIndex(e => e.ThemeId, "voyager_theme_options_theme_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.ThemeId).HasColumnName("theme_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");

            entity.HasOne(d => d.Theme).WithMany(p => p.ThemeOptions)
                .HasForeignKey(d => d.ThemeId)
                .HasConstraintName("theme_options_theme_id_foreign");
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("translations");

            entity.HasIndex(e => new { e.TableName, e.ColumnName, e.ForeignKey, e.Locale }, "translations_table_name_column_name_foreign_key_locale_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(191)
                .HasColumnName("column_name");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ForeignKey).HasColumnName("foreign_key");
            entity.Property(e => e.Locale)
                .HasMaxLength(191)
                .HasColumnName("locale");
            entity.Property(e => e.TableName)
                .HasMaxLength(191)
                .HasColumnName("table_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("text")
                .HasColumnName("value");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.CoopInfoId, "users_coop_info_id_foreign");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.HasIndex(e => e.RoleId, "users_role_id_foreign");

            entity.HasIndex(e => e.UserConfigId, "users_user_config_id_foreign");

            entity.HasIndex(e => e.UserKey, "users_user_key_unique").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnalyticsUrl)
                .HasMaxLength(180)
                .HasColumnName("analytics_url");
            entity.Property(e => e.Avatar)
                .HasMaxLength(191)
                .HasDefaultValueSql("'users/default.png'")
                .HasColumnName("avatar");
            entity.Property(e => e.CardBrand)
                .HasMaxLength(191)
                .HasColumnName("card_brand");
            entity.Property(e => e.CardLastFour)
                .HasMaxLength(191)
                .HasColumnName("card_last_four");
            entity.Property(e => e.CoopInfoId).HasColumnName("coop_info_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerifiedAt)
                .HasColumnType("timestamp")
                .HasColumnName("email_verified_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(191)
                .HasColumnName("password");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Settings)
                .HasColumnType("text")
                .HasColumnName("settings");
            entity.Property(e => e.StripeId)
                .HasMaxLength(191)
                .HasColumnName("stripe_id");
            entity.Property(e => e.TrialEndsAt)
                .HasColumnType("datetime")
                .HasColumnName("trial_ends_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserConfigId).HasColumnName("user_config_id");
            entity.Property(e => e.UserKey)
                .HasMaxLength(32)
                .HasColumnName("user_key");
            entity.Property(e => e.Username)
                .HasMaxLength(191)
                .HasColumnName("username");
            entity.Property(e => e.VerificationCode)
                .HasMaxLength(191)
                .HasColumnName("verification_code");
            entity.Property(e => e.Verified).HasColumnName("verified");
            entity.Property(e => e.WebArTemplate)
                .HasMaxLength(191)
                .HasComment("WebAR MP 用で利用する テンプレート")
                .HasColumnName("web_ar_template");

            entity.HasOne(d => d.CoopInfo).WithMany(p => p.Users)
                .HasForeignKey(d => d.CoopInfoId)
                .HasConstraintName("users_coop_info_id_foreign");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_role_id_foreign");

            entity.HasOne(d => d.UserConfig).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserConfigId)
                .HasConstraintName("users_user_config_id_foreign");

            entity.HasMany(d => d.Roles).WithMany(p => p.UsersNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("user_roles_role_id_foreign"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_roles_user_id_foreign"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PRIMARY");
                        j.ToTable("user_roles");
                        j.HasIndex(new[] { "RoleId" }, "user_roles_role_id_index");
                        j.HasIndex(new[] { "UserId" }, "user_roles_user_id_index");
                        j.IndexerProperty<uint>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<ulong>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<UserConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_config");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.ShowExOption1).HasColumnName("show_ex_option_1");
            entity.Property(e => e.ShowOldFunction).HasColumnName("show_old_function");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserViewGroupMp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_view_group_mp");

            entity.HasIndex(e => new { e.AuthorId, e.YyyyMm, e.GroupMpId }, "user_view_group_mp_author_id_yyyy_mm_group_mp_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.GroupMpId)
                .HasComment("MP ID")
                .HasColumnName("group_mp_id");
            entity.Property(e => e.ViewCount)
                .HasComment("ビュー数")
                .HasColumnName("view_count");
            entity.Property(e => e.YyyyMm)
                .HasComment("YYYYMM")
                .HasColumnName("yyyy_mm");
        });

        modelBuilder.Entity<UserViewMp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_view_mp");

            entity.HasIndex(e => new { e.AuthorId, e.YyyyMm, e.MpId }, "user_view_mp_author_id_yyyy_mm_mp_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.MpId)
                .HasComment("MP ID")
                .HasColumnName("mp_id");
            entity.Property(e => e.ViewCount)
                .HasComment("ビュー数")
                .HasColumnName("view_count");
            entity.Property(e => e.YyyyMm)
                .HasComment("YYYYMM")
                .HasColumnName("yyyy_mm");
        });

        modelBuilder.Entity<UserViewTotal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_view_totals");

            entity.HasIndex(e => new { e.AuthorId, e.YyyyMm }, "user_view_totals_author_id_yyyy_mm_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.GroupMpViewCount)
                .HasComment("MP グループページビュー数")
                .HasColumnName("group_mp_view_count");
            entity.Property(e => e.MpViewCount)
                .HasComment("MP ページビュー数")
                .HasColumnName("mp_view_count");
            entity.Property(e => e.NotifiedFlg)
                .HasComment("通知済みフラグ")
                .HasColumnName("notified_flg");
            entity.Property(e => e.YyyyMm)
                .HasComment("YYYYMM")
                .HasColumnName("yyyy_mm");
        });

        modelBuilder.Entity<VideoCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_categories");

            entity.HasIndex(e => e.Slug, "video_categories_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasComment("カテゴリ 日本語名")
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasComment("並び替え順")
                .HasColumnName("order");
            entity.Property(e => e.Slug)
                .HasMaxLength(191)
                .HasComment("カテゴリ 英名")
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<VideoFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_files");

            entity.HasIndex(e => e.AuthorId, "video_files_author_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Duration)
                .HasComment("動画の長さ")
                .HasColumnName("duration");
            entity.Property(e => e.Filename)
                .HasMaxLength(191)
                .HasComment("元々の動画の名前")
                .HasColumnName("filename");
            entity.Property(e => e.Filepath)
                .HasMaxLength(191)
                .HasComment("動画のS3上のパス　拡張子を含めたフルパス")
                .HasColumnName("filepath");
            entity.Property(e => e.Filesize)
                .HasComment("動画のデータ容量")
                .HasColumnName("filesize");
            entity.Property(e => e.Fps)
                .HasComment("動画のFPS")
                .HasColumnType("double(8,2)")
                .HasColumnName("fps");
            entity.Property(e => e.Height)
                .HasComment("動画の縦幅px")
                .HasColumnName("height");
            entity.Property(e => e.OwnerProjectId).HasColumnName("owner_project_id");
            entity.Property(e => e.Rotate).HasColumnName("rotate");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Width)
                .HasComment("動画の横幅px")
                .HasColumnName("width");

            entity.HasOne(d => d.Author).WithMany(p => p.VideoFiles)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("video_files_author_id_foreign");
        });

        modelBuilder.Entity<VideoGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_group");

            entity.HasIndex(e => e.AuthorId, "video_group_author_id_foreign");

            entity.HasIndex(e => new { e.Code, e.Exist }, "video_group_code_exist_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.Code)
                .HasMaxLength(191)
                .HasComment("視聴コード")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasComment("概要")
                .HasColumnName("description");
            entity.Property(e => e.Exist).HasColumnName("exist");
            entity.Property(e => e.SelectedItems)
                .HasMaxLength(191)
                .HasComment("選択されているMP一覧")
                .HasColumnName("selected_items");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasComment("ビデオグループタイトル")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebArTemplate)
                .HasMaxLength(30)
                .HasComment("WebAR MP グループ で利用する テンプレート")
                .HasColumnName("web_ar_template");

            entity.HasOne(d => d.Author).WithMany(p => p.VideoGroups)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("video_group_author_id_foreign");
        });

        modelBuilder.Entity<VideoGroupVideoProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_group_video_projects");

            entity.HasIndex(e => new { e.VideoGroupId, e.VideoProjectId }, "group_id_project_id_unique").IsUnique();

            entity.HasIndex(e => e.VideoProjectId, "video_group_video_projects_video_project_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.VideoGroupId)
                .HasComment("動画グループの外部キー")
                .HasColumnName("video_group_id");
            entity.Property(e => e.VideoProjectId)
                .HasComment("ビデオプロジェクトの外部キー")
                .HasColumnName("video_project_id");

            entity.HasOne(d => d.VideoGroup).WithMany(p => p.VideoGroupVideoProjects)
                .HasForeignKey(d => d.VideoGroupId)
                .HasConstraintName("video_group_video_projects_video_group_id_foreign");

            entity.HasOne(d => d.VideoProject).WithMany(p => p.VideoGroupVideoProjects)
                .HasForeignKey(d => d.VideoProjectId)
                .HasConstraintName("video_group_video_projects_video_project_id_foreign");
        });

        modelBuilder.Entity<VideoOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_options");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArIconEditParamJson)
                .HasComment("ARアイコン編集用情報")
                .HasColumnName("ar_icon_edit_param_json");
            entity.Property(e => e.ArIconImageId)
                .HasComment("ARアイコンの画像番号")
                .HasColumnName("ar_icon_image_id");
            entity.Property(e => e.ArIconJsonInfo)
                .HasComment("ARアイコンの位置情報を記録する値 Json 形式で格納")
                .HasColumnName("ar_icon_json_info");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.MpLinkEditInfo)
                .HasComment("MP リンク情報を 編集するために利用する追加情報")
                .HasColumnName("mp_link_edit_info");
            entity.Property(e => e.MpLinkJsonInfo)
                .HasComment("関連する MP 情報の格納された Json 形式データ")
                .HasColumnName("mp_link_json_info");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<VideoProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_projects");

            entity.HasIndex(e => e.ArImageId, "video_projects_ar_image_id_foreign");

            entity.HasIndex(e => e.AuthorId, "video_projects_author_id_foreign");

            entity.HasIndex(e => new { e.Code, e.Exist }, "video_projects_code_exist_unique").IsUnique();

            entity.HasIndex(e => e.ConvertedVideoId, "video_projects_converted_video_id_foreign");

            entity.HasIndex(e => e.OverwrapImageId, "video_projects_overwrap_image_id_foreign");

            entity.HasIndex(e => e.TitleImageId, "video_projects_title_image_id_foreign");

            entity.HasIndex(e => e.VideoCategoryId, "video_projects_video_category_id_foreign");

            entity.HasIndex(e => e.VideoUnitId, "video_projects_video_unit_id_foreign");

            entity.HasIndex(e => e.WebArConvertedVideoId, "video_projects_web_ar_converted_video_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionUrl)
                .HasMaxLength(191)
                .HasColumnName("action_url");
            entity.Property(e => e.ActionUrlAskFlg).HasColumnName("action_url_ask_flg");
            entity.Property(e => e.ArAreaAnimation)
                .HasDefaultValueSql("'1'")
                .HasColumnName("ar_area_animation");
            entity.Property(e => e.ArExecMode)
                .HasDefaultValueSql("'1'")
                .HasColumnName("ar_exec_mode");
            entity.Property(e => e.ArImageId)
                .HasComment("静止画の外部キー")
                .HasColumnName("ar_image_id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.AutoEnd)
                .HasDefaultValueSql("'1'")
                .HasColumnName("auto_end");
            entity.Property(e => e.AutoStart)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("auto_start");
            entity.Property(e => e.Code)
                .HasMaxLength(191)
                .HasComment("視聴コード")
                .HasColumnName("code");
            entity.Property(e => e.ConvertedVideoId)
                .HasComment("出力動画の外部キー")
                .HasColumnName("converted_video_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasComment("動画概要")
                .HasColumnName("description");
            entity.Property(e => e.EffectType).HasColumnName("effect_type");
            entity.Property(e => e.EndAt)
                .HasComment("動画終了日時")
                .HasColumnType("datetime")
                .HasColumnName("end_at");
            entity.Property(e => e.Exist).HasColumnName("exist");
            entity.Property(e => e.OverwrapImageId).HasColumnName("overwrap_image_id");
            entity.Property(e => e.PublicFlg).HasColumnName("public_flg");
            entity.Property(e => e.StartAt)
                .HasComment("動画開始日時")
                .HasColumnType("datetime")
                .HasColumnName("start_at");
            entity.Property(e => e.Title)
                .HasMaxLength(191)
                .HasComment("動画タイトル")
                .HasColumnName("title");
            entity.Property(e => e.TitleImageId).HasColumnName("title_image_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserBatchDownloadFlg)
                .HasComment("一括ダウンロードフラグ")
                .HasColumnName("user_batch_download_flg");
            entity.Property(e => e.VideoCategoryId)
                .HasComment("ビデオカテゴリの外部キー")
                .HasColumnName("video_category_id");
            entity.Property(e => e.VideoNoResize).HasColumnName("video_no_resize");
            entity.Property(e => e.VideoOptionId).HasColumnName("video_option_id");
            entity.Property(e => e.VideoUnitId)
                .HasComment("動画ユニットの外部キー")
                .HasColumnName("video_unit_id");
            entity.Property(e => e.WebArConvertedVideoId)
                .HasComment("WebAr用のビデオ")
                .HasColumnName("web_ar_converted_video_id");
            entity.Property(e => e.WebArTemplate)
                .HasMaxLength(30)
                .HasComment("WebAR MP 用で利用する テンプレート")
                .HasColumnName("web_ar_template");

            entity.HasOne(d => d.ArImage).WithMany(p => p.VideoProjectArImages)
                .HasForeignKey(d => d.ArImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_ar_image_id_foreign");

            entity.HasOne(d => d.Author).WithMany(p => p.VideoProjects)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("video_projects_author_id_foreign");

            entity.HasOne(d => d.ConvertedVideo).WithMany(p => p.VideoProjectConvertedVideos)
                .HasForeignKey(d => d.ConvertedVideoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_converted_video_id_foreign");

            entity.HasOne(d => d.OverwrapImage).WithMany(p => p.VideoProjectOverwrapImages)
                .HasForeignKey(d => d.OverwrapImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_overwrap_image_id_foreign");

            entity.HasOne(d => d.TitleImage).WithMany(p => p.VideoProjectTitleImages)
                .HasForeignKey(d => d.TitleImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_title_image_id_foreign");

            entity.HasOne(d => d.VideoCategory).WithMany(p => p.VideoProjects)
                .HasForeignKey(d => d.VideoCategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_video_category_id_foreign");

            entity.HasOne(d => d.VideoUnit).WithMany(p => p.VideoProjects)
                .HasForeignKey(d => d.VideoUnitId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_video_unit_id_foreign");

            entity.HasOne(d => d.WebArConvertedVideo).WithMany(p => p.VideoProjectWebArConvertedVideos)
                .HasForeignKey(d => d.WebArConvertedVideoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_projects_web_ar_converted_video_id_foreign");
        });

        modelBuilder.Entity<VideoProjectOptionImageFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_project_option_image_files");

            entity.HasIndex(e => e.ImageFileId, "video_project_option_image_files_image_file_id_foreign");

            entity.HasIndex(e => e.VideoProjectId, "video_project_option_image_files_video_project_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionParam)
                .HasMaxLength(250)
                .HasColumnName("action_param");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Enabled)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("enabled");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.ImageFileId)
                .HasComment("画像ファイルの外部キー")
                .HasColumnName("image_file_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VideoProjectId)
                .HasComment("プロジェクトの外部キー")
                .HasColumnName("video_project_id");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");
            entity.Property(e => e.Z).HasColumnName("z");

            entity.HasOne(d => d.ImageFile).WithMany(p => p.VideoProjectOptionImageFiles)
                .HasForeignKey(d => d.ImageFileId)
                .HasConstraintName("video_project_option_image_files_image_file_id_foreign");

            entity.HasOne(d => d.VideoProject).WithMany(p => p.VideoProjectOptionImageFiles)
                .HasForeignKey(d => d.VideoProjectId)
                .HasConstraintName("video_project_option_image_files_video_project_id_foreign");
        });

        modelBuilder.Entity<VideoType>(entity =>
        {
            entity.HasKey(e => e.Type).HasName("PRIMARY");

            entity.ToTable("video_types");

            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<VideoUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_units");

            entity.HasIndex(e => e.AuthorId, "video_units_author_id_foreign");

            entity.HasIndex(e => e.ConvertedVideoId, "video_units_converted_video_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasComment("作成者")
                .HasColumnName("author_id");
            entity.Property(e => e.ConvertedVideoId)
                .HasComment("出力動画の外部キー")
                .HasColumnName("converted_video_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Fps)
                .HasComment("動画のFPS")
                .HasColumnType("double(8,2)")
                .HasColumnName("fps");
            entity.Property(e => e.Height)
                .HasComment("動画の縦幅px")
                .HasColumnName("height");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Width)
                .HasComment("動画の横幅px")
                .HasColumnName("width");

            entity.HasOne(d => d.Author).WithMany(p => p.VideoUnits)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("video_units_author_id_foreign");

            entity.HasOne(d => d.ConvertedVideo).WithMany(p => p.VideoUnits)
                .HasForeignKey(d => d.ConvertedVideoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("video_units_converted_video_id_foreign");
        });

        modelBuilder.Entity<VideoUnitsVideoFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("video_units_video_files");

            entity.HasIndex(e => e.VideoFileId, "video_units_video_files_video_file_id_foreign");

            entity.HasIndex(e => new { e.VideoUnitId, e.VideoFileId }, "video_units_video_files_video_unit_id_video_file_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Order)
                .HasComment("動画ユニットに対しての並び順")
                .HasColumnName("order");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.VideoFileId)
                .HasComment("動画ファイルの外部キー")
                .HasColumnName("video_file_id");
            entity.Property(e => e.VideoUnitId)
                .HasComment("動画ユニットの外部キー")
                .HasColumnName("video_unit_id");

            entity.HasOne(d => d.VideoFile).WithMany(p => p.VideoUnitsVideoFiles)
                .HasForeignKey(d => d.VideoFileId)
                .HasConstraintName("video_units_video_files_video_file_id_foreign");

            entity.HasOne(d => d.VideoUnit).WithMany(p => p.VideoUnitsVideoFiles)
                .HasForeignKey(d => d.VideoUnitId)
                .HasConstraintName("video_units_video_files_video_unit_id_foreign");
        });

        modelBuilder.Entity<WaveKeyValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("wave_key_values");

            entity.HasIndex(e => new { e.KeyvalueId, e.KeyvalueType, e.Key }, "wave_key_values_keyvalue_id_keyvalue_type_key_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Key)
                .HasMaxLength(191)
                .HasColumnName("key");
            entity.Property(e => e.KeyvalueId).HasColumnName("keyvalue_id");
            entity.Property(e => e.KeyvalueType)
                .HasMaxLength(191)
                .HasColumnName("keyvalue_type");
            entity.Property(e => e.Type)
                .HasMaxLength(191)
                .HasColumnName("type");
            entity.Property(e => e.Value)
                .HasMaxLength(191)
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
