using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace veterinaryClinic;

public partial class PostgresContext : DbContext
{
    private string _userName;
    private string _password;
    public PostgresContext(string userName, string password)
    {
        _userName = userName;
        _password = password;
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analysisresult> Analysisresults { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Animalsinfo> Animalsinfos { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Datetimeofreception> Datetimeofreceptions { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipmentclass> Equipmentclasses { get; set; }

    public virtual DbSet<Equipmentclinic> Equipmentclinics { get; set; }

    public virtual DbSet<Medicalitem> Medicalitems { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Ownerofanimal> Ownerofanimals { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Serviceclass> Serviceclasses { get; set; }

    public virtual DbSet<Typeofanimal> Typeofanimals { get; set; }

    public virtual DbSet<Useofclinicequipment> Useofclinicequipments { get; set; }

    public virtual DbSet<Useofmedicalitem> Useofmedicalitems { get; set; }

    public virtual DbSet<Useofmedicine> Useofmedicines { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userlog> Userlogs { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    public virtual DbSet<Vaccinationsdelivered> Vaccinationsdelivereds { get; set; }

    public virtual DbSet<Veterinaryclinic> Veterinaryclinics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username={_userName};Password={_password}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "adminpack")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Analysisresult>(entity =>
        {
            entity.HasKey(e => e.Idanalysisresults).HasName("analysisresults_pkey");

            entity.ToTable("analysisresults");

            entity.Property(e => e.Idanalysisresults).HasColumnName("idanalysisresults");
            entity.Property(e => e.DateOfResult).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Animals).WithMany(p => p.Analysisresults)
                .HasForeignKey(d => d.AnimalsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysisresults_AnimalsId_fkey");

            entity.HasOne(d => d.Employess).WithMany(p => p.Analysisresults)
                .HasForeignKey(d => d.EmployessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("analysisresults_EmployessId_fkey");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Idanimals).HasName("animals_pkey");

            entity.ToTable("animals");

            entity.Property(e => e.Idanimals).HasColumnName("idanimals");
            entity.Property(e => e.Breed).HasMaxLength(45);
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Features).HasMaxLength(155);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.NameOfAnimals).HasMaxLength(16);
            entity.Property(e => e.NumberOfElectronicChip).HasMaxLength(64);
            entity.Property(e => e.Photo).HasMaxLength(100);

            entity.HasOne(d => d.TypeOfAnimalsNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.TypeOfAnimals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("animals_TypeOfAnimals_fkey");
        });

        modelBuilder.Entity<Animalsinfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("animalsinfo");

            entity.Property(e => e.Breed).HasMaxLength(45);
            entity.Property(e => e.Idanimals).HasColumnName("idanimals");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(11)
                .IsFixedLength();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Idappointment).HasName("appointment_pkey");

            entity.ToTable("appointment");

            entity.Property(e => e.Idappointment).HasColumnName("idappointment");
            entity.Property(e => e.DateTimeOfEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateTimeOfStart).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Employeesid).HasColumnName("employeesid");
            entity.Property(e => e.Notes).HasMaxLength(100);

            entity.HasOne(d => d.Animals).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AnimalsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_AnimalsId_fkey");

            entity.HasOne(d => d.Employees).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Employeesid)
                .HasConstraintName("appointment_employeesid_fkey");
        });

        modelBuilder.Entity<Datetimeofreception>(entity =>
        {
            entity.HasKey(e => e.Iddatetimeofreception).HasName("datetimeofreception_pkey");

            entity.ToTable("datetimeofreception");

            entity.Property(e => e.Iddatetimeofreception).HasColumnName("iddatetimeofreception");
            entity.Property(e => e.DateTimeOfEnd).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DateTimeOfStart).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Employees).WithMany(p => p.Datetimeofreceptions)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("datetimeofreception_EmployeesId_fkey");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.Iddiagnosis).HasName("diagnosis_pkey");

            entity.ToTable("diagnosis");

            entity.Property(e => e.Iddiagnosis).HasColumnName("iddiagnosis");

            entity.HasOne(d => d.Animals).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.AnimalsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnosis_AnimalsId_fkey");

            entity.HasOne(d => d.Employees).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diagnosis_EmployeesId_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployees).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Idemployees).HasColumnName("idemployees");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Education).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(16);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.PassportSeries)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(11)
                .IsFixedLength();

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_PositionId_fkey");

            entity.HasMany(d => d.Classservices).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeesclassservice",
                    r => r.HasOne<Serviceclass>().WithMany()
                        .HasForeignKey("Classservicesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeesclassservices_classservicesid_fkey"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeesclassservices_employeesid_fkey"),
                    j =>
                    {
                        j.HasKey("Employeesid", "Classservicesid").HasName("employeesclassservices_pkey");
                        j.ToTable("employeesclassservices");
                        j.IndexerProperty<int>("Employeesid").HasColumnName("employeesid");
                        j.IndexerProperty<int>("Classservicesid").HasColumnName("classservicesid");
                    });

            entity.HasMany(d => d.Veterinaryclinics).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeesofveterinaryclinic",
                    r => r.HasOne<Veterinaryclinic>().WithMany()
                        .HasForeignKey("Veterinaryclinicid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeesofveterinaryclinic_veterinaryclinicid_fkey"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employeesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employeesofveterinaryclinic_employeesid_fkey"),
                    j =>
                    {
                        j.HasKey("Employeesid", "Veterinaryclinicid").HasName("employeesofveterinaryclinic_pkey");
                        j.ToTable("employeesofveterinaryclinic");
                        j.IndexerProperty<int>("Employeesid").HasColumnName("employeesid");
                        j.IndexerProperty<int>("Veterinaryclinicid").HasColumnName("veterinaryclinicid");
                    });
        });

        modelBuilder.Entity<Equipmentclass>(entity =>
        {
            entity.HasKey(e => e.Idequipmentclass).HasName("equipmentclass_pkey");

            entity.ToTable("equipmentclass");

            entity.Property(e => e.Idequipmentclass).HasColumnName("idequipmentclass");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Equipmentclinic>(entity =>
        {
            entity.HasKey(e => e.Idequipmentclinic).HasName("equipmentclinic_pkey");

            entity.ToTable("equipmentclinic");

            entity.Property(e => e.Idequipmentclinic).HasColumnName("idequipmentclinic");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.EquipmentClass).WithMany(p => p.Equipmentclinics)
                .HasForeignKey(d => d.EquipmentClassId)
                .HasConstraintName("equipmentclinic_EquipmentClassId_fkey");

            entity.HasOne(d => d.VeterinaryClinic).WithMany(p => p.Equipmentclinics)
                .HasForeignKey(d => d.VeterinaryClinicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("equipmentclinic_VeterinaryClinicId_fkey");
        });

        modelBuilder.Entity<Medicalitem>(entity =>
        {
            entity.HasKey(e => e.Idmedicalitem).HasName("medicalitem_pkey");

            entity.ToTable("medicalitem");

            entity.Property(e => e.Idmedicalitem).HasColumnName("idmedicalitem");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(9, 2);
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Idmedicines).HasName("medicines_pkey");

            entity.ToTable("medicines");

            entity.Property(e => e.Idmedicines).HasColumnName("idmedicines");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(12, 2);

            entity.HasMany(d => d.Types).WithMany(p => p.Medicines)
                .UsingEntity<Dictionary<string, object>>(
                    "Typeofmedicine",
                    r => r.HasOne<Typeofanimal>().WithMany()
                        .HasForeignKey("Typeid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typeofmedicines_typeofanimal_idtypeofanimal_fk"),
                    l => l.HasOne<Medicine>().WithMany()
                        .HasForeignKey("Medicinesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typeofmedicines_medicines_idmedicines_fk"),
                    j =>
                    {
                        j.HasKey("Medicinesid", "Typeid").HasName("typeofmedicines_pk");
                        j.ToTable("typeofmedicines");
                        j.IndexerProperty<int>("Medicinesid").HasColumnName("medicinesid");
                        j.IndexerProperty<int>("Typeid").HasColumnName("typeid");
                    });
        });

        modelBuilder.Entity<Ownerofanimal>(entity =>
        {
            entity.HasKey(e => e.Idownerofanimals).HasName("ownerofanimals_pkey");

            entity.ToTable("ownerofanimals");

            entity.Property(e => e.Idownerofanimals).HasColumnName("idownerofanimals");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(12);
            entity.Property(e => e.Passportnumber)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("passportnumber");
            entity.Property(e => e.Passportseries)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("passportseries");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(11)
                .IsFixedLength();

            entity.HasMany(d => d.Idanimals).WithMany(p => p.Idanimalsowners)
                .UsingEntity<Dictionary<string, object>>(
                    "Allanimalsofowner",
                    r => r.HasOne<Animal>().WithMany()
                        .HasForeignKey("Idanimals")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("allanimalsofowner_idanimals_fkey"),
                    l => l.HasOne<Ownerofanimal>().WithMany()
                        .HasForeignKey("Idanimalsowner")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("allanimalsofowner_idanimalsowner_fkey"),
                    j =>
                    {
                        j.HasKey("Idanimalsowner", "Idanimals").HasName("allanimalsofowner_pkey");
                        j.ToTable("allanimalsofowner");
                        j.IndexerProperty<int>("Idanimalsowner").HasColumnName("idanimalsowner");
                        j.IndexerProperty<int>("Idanimals").HasColumnName("idanimals");
                    });
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Idpositions).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.Idpositions).HasColumnName("idpositions");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Requirements).HasMaxLength(100);
            entity.Property(e => e.Responsibilities).HasMaxLength(255);
            entity.Property(e => e.Salary).HasPrecision(7, 2);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Idservices).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Idservices).HasColumnName("idservices");
            entity.Property(e => e.Descriprion).HasMaxLength(255);
            entity.Property(e => e.IdServiceClass).HasColumnName("idServiceClass");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Price).HasPrecision(9, 2);

            entity.HasOne(d => d.IdServiceClassNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.IdServiceClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("services_idServiceClass_fkey");

            entity.HasMany(d => d.Appointments).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "Servicesofappointment",
                    r => r.HasOne<Appointment>().WithMany()
                        .HasForeignKey("Appointmentid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("servicesofappointment_appointmentid_fkey"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("Servicesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("servicesofappointment_servicesid_fkey"),
                    j =>
                    {
                        j.HasKey("Servicesid", "Appointmentid").HasName("servicesofappointment_pkey");
                        j.ToTable("servicesofappointment");
                        j.IndexerProperty<int>("Servicesid").HasColumnName("servicesid");
                        j.IndexerProperty<int>("Appointmentid").HasColumnName("appointmentid");
                    });

            entity.HasMany(d => d.Types).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "Typeanimalsofservice",
                    r => r.HasOne<Typeofanimal>().WithMany()
                        .HasForeignKey("Typeid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typeanimalsofservices_typeid_fkey"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("Servicesid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typeanimalsofservices_servicesid_fkey"),
                    j =>
                    {
                        j.HasKey("Servicesid", "Typeid").HasName("typeanimalsofservices_pkey");
                        j.ToTable("typeanimalsofservices");
                        j.IndexerProperty<int>("Servicesid").HasColumnName("servicesid");
                        j.IndexerProperty<int>("Typeid").HasColumnName("typeid");
                    });
        });

        modelBuilder.Entity<Serviceclass>(entity =>
        {
            entity.HasKey(e => e.Idserviceclass).HasName("serviceclass_pkey");

            entity.ToTable("serviceclass");

            entity.Property(e => e.Idserviceclass).HasColumnName("idserviceclass");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Typeofanimal>(entity =>
        {
            entity.HasKey(e => e.Idtypeofanimal).HasName("typeofanimal_pkey");

            entity.ToTable("typeofanimal");

            entity.Property(e => e.Idtypeofanimal).HasColumnName("idtypeofanimal");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Useofclinicequipment>(entity =>
        {
            entity.HasKey(e => new { e.Employeesid, e.Equipmentid, e.Datetimeofuse }).HasName("useofclinicequipment_pkey");

            entity.ToTable("useofclinicequipment");

            entity.Property(e => e.Employeesid).HasColumnName("employeesid");
            entity.Property(e => e.Equipmentid).HasColumnName("equipmentid");
            entity.Property(e => e.Datetimeofuse)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimeofuse");

            entity.HasOne(d => d.Employees).WithMany(p => p.Useofclinicequipments)
                .HasForeignKey(d => d.Employeesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofclinicequipment_employeesid_fkey");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Useofclinicequipments)
                .HasForeignKey(d => d.Equipmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofclinicequipment_equipmentid_fkey");
        });

        modelBuilder.Entity<Useofmedicalitem>(entity =>
        {
            entity.HasKey(e => new { e.Medicalitemid, e.Employeesid, e.Datetimeofuse }).HasName("useofmedicalitem_pkey");

            entity.ToTable("useofmedicalitem");

            entity.Property(e => e.Medicalitemid).HasColumnName("medicalitemid");
            entity.Property(e => e.Employeesid).HasColumnName("employeesid");
            entity.Property(e => e.Datetimeofuse)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimeofuse");
            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Useofmedicalitems)
                .HasForeignKey(d => d.Appointmentid)
                .HasConstraintName("useofmedicalitem_appointment_idappointment_fk");

            entity.HasOne(d => d.Employees).WithMany(p => p.Useofmedicalitems)
                .HasForeignKey(d => d.Employeesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofmedicalitem_employeesid_fkey");

            entity.HasOne(d => d.Medicalitem).WithMany(p => p.Useofmedicalitems)
                .HasForeignKey(d => d.Medicalitemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofmedicalitem_medicalitemid_fkey");
        });

        modelBuilder.Entity<Useofmedicine>(entity =>
        {
            entity.HasKey(e => new { e.Medecinesid, e.Employeesid, e.Datetimeofuse }).HasName("useofmedicines_pkey");

            entity.ToTable("useofmedicines");

            entity.Property(e => e.Medecinesid).HasColumnName("medecinesid");
            entity.Property(e => e.Employeesid).HasColumnName("employeesid");
            entity.Property(e => e.Datetimeofuse)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimeofuse");
            entity.Property(e => e.Appointmentid).HasColumnName("appointmentid");
            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Useofmedicines)
                .HasForeignKey(d => d.Appointmentid)
                .HasConstraintName("useofmedicines_appointment_idappointment_fk");

            entity.HasOne(d => d.Employees).WithMany(p => p.Useofmedicines)
                .HasForeignKey(d => d.Employeesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofmedicines_employeesid_fkey");

            entity.HasOne(d => d.Medecines).WithMany(p => p.Useofmedicines)
                .HasForeignKey(d => d.Medecinesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useofmedicines_medecinesid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Usersid).HasName("users_pk");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_pk_2").IsUnique();

            entity.Property(e => e.Usersid).HasColumnName("usersid");
            entity.Property(e => e.Employeesid).HasColumnName("employeesid");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.HasOne(d => d.Employees).WithMany(p => p.Users)
                .HasForeignKey(d => d.Employeesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_employees_idemployees_fk");
        });

        modelBuilder.Entity<Userlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("userlog");

            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.Idvaccinations).HasName("vaccinations_pkey");

            entity.ToTable("vaccinations");

            entity.Property(e => e.Idvaccinations).HasColumnName("idvaccinations");
            entity.Property(e => e.Features).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Vaccinationsdelivered>(entity =>
        {
            entity.HasKey(e => new { e.Animalsid, e.Vaccanationsid, e.Datetimeofvaccanations }).HasName("vaccinationsdelivered_pkey");

            entity.ToTable("vaccinationsdelivered");

            entity.Property(e => e.Animalsid).HasColumnName("animalsid");
            entity.Property(e => e.Vaccanationsid).HasColumnName("vaccanationsid");
            entity.Property(e => e.Datetimeofvaccanations)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimeofvaccanations");

            entity.HasOne(d => d.Animals).WithMany(p => p.Vaccinationsdelivereds)
                .HasForeignKey(d => d.Animalsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vaccinationsdelivered_animalsid_fkey");

            entity.HasOne(d => d.Vaccanations).WithMany(p => p.Vaccinationsdelivereds)
                .HasForeignKey(d => d.Vaccanationsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vaccinationsdelivered_vaccanationsid_fkey");
        });

        modelBuilder.Entity<Veterinaryclinic>(entity =>
        {
            entity.HasKey(e => e.Idveterinaryclinic).HasName("veterinaryclinic_pkey");

            entity.ToTable("veterinaryclinic");

            entity.Property(e => e.Idveterinaryclinic).HasColumnName("idveterinaryclinic");
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
