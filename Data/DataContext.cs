using Backend.Models;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Subject> Subjects => Set<Subject>();

        // public DbSet<Region> Regions => Set<Region>();

        public DbSet<Mission> Missions => Set<Mission>();

        public DbSet<SubMission> SubMissions => Set<SubMission>();

        public DbSet<QSTSubMission> QSTSubMissions => Set<QSTSubMission>();

        public DbSet<Quest> Questions => Set<Quest>();

        public DbSet<AreaManager> AreaManagers => Set<AreaManager>();

        public DbSet<Store> Stores => Set<Store>();

        public DbSet<SubRegion> SubRegions => Set<SubRegion>();

        public DbSet<Region> Regions => Set<Region>();

        public DbSet<Group> Groups => Set<Group>();

        public DbSet<Affectation> Affectations => Set<Affectation>();

        public DbSet<Visit> Visits => Set<Visit>();

    }
}