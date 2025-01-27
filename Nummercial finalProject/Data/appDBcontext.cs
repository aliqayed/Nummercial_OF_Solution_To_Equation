namespace Nummercial_finalProject.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Problem>? Problems { get; set; }
        public DbSet<ProblemR>? ProblemsR { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultR> ResultRs { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        // ConfigureServices
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Problem>()
                .HasKey(p => p.Id);


            modelBuilder.Entity<ProblemR>()
                .HasKey(PR => PR.Id);
            modelBuilder.Entity<ResultR>()
              .HasKey(PR => PR.Id);



            // Configure other relationships and indexes
            modelBuilder.Entity<Result>()
                .HasKey(r => r.Id); // Primary key for Result

            modelBuilder.Entity<Person>()
                .HasKey(pe => pe.Id); // Primary key for Person


            modelBuilder.Entity<Problem>()
                .HasOne(p => p.Result)
                .WithOne(r => r.Problem)
                .HasForeignKey<Result>(r => r.ProblemId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProblemR>()
                .HasOne(p => p.ResultR)
                .WithOne(r => r.ProblemR)
                .HasForeignKey<ResultR>(r => r.ProblemRId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ProblemR>()
                .HasOne(p => p.Person)
                .WithMany(person => person.ProblemsR)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Problem>()
                .HasOne(p => p.Person)
                .WithMany(person => person.Problems)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Problem>().HasIndex(p => p.ResultId);
            modelBuilder.Entity<ProblemR>().HasIndex(p => p.ResultIdR);



        }



    }
}

