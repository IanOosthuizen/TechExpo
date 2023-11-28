using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TechSPO.Models;

public partial class TechspoContext : DbContext
{
    public TechspoContext()
    {
    }

    public TechspoContext(DbContextOptions<TechspoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1F1HII2;Initial Catalog=Techspo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.HasKey(e => e.AttendeeId).HasName("PK__Attendee__77C4E3996DE6DE8A");

            entity.Property(e => e.AttendeeId).HasColumnName("attendeeID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contactInfo");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.GroupDetails)
                .HasColumnType("text")
                .HasColumnName("groupDetails");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Event).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Attendees__event__33D4B598");
        });

        modelBuilder.Entity<DiscountCode>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Discount__357D4CF8C69F58D5");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercentage");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("date")
                .HasColumnName("expirationDate");

            entity.HasOne(d => d.Event).WithMany(p => p.DiscountCodes)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__DiscountC__event__36B12243");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2DC7BD690BF1DA00");

            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Theme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("theme");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__2ECD6E242ADDD425");

            entity.Property(e => e.ReviewId).HasColumnName("reviewID");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate)
                .HasColumnType("date")
                .HasColumnName("reviewDate");
            entity.Property(e => e.ReviewText)
                .HasColumnType("text")
                .HasColumnName("reviewText");
            entity.Property(e => e.ReviewerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reviewerName");
            entity.Property(e => e.SessionId).HasColumnName("sessionID");

            entity.HasOne(d => d.Event).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Reviews__eventID__3E52440B");

            entity.HasOne(d => d.Session).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Reviews__session__3F466844");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__23DB12CB72C1D0CC");

            entity.Property(e => e.SessionId).HasColumnName("sessionID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.SessionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sessionName");
            entity.Property(e => e.Speaker)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("speaker");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.Event).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Sessions__eventI__30F848ED");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDFDEA9B336");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registrationDate");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
