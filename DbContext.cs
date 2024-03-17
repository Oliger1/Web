using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;


namespace WebOliger.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<AdminRole> AdminRoles { get; set; }

        public DbSet<ResumeModel> Resumes { get; set; }
    }





    public class ResumeModel
    {
        internal string? file;

        public int Id { get; set; }

    
        public string Title { get; set; }

        public string Description { get; set; }

        public string DownloadLink { get; set; }

        public string Category { get; set; }
        public List<string> UploadedDocumentsPaths { get; set; } = new List<string>();

    }
}
