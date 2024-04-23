using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebOliger.Entity;

namespace WebOliger.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReviewModel> Reviews { get; set; }

        public DbSet<ResumeModel> Resumes { get; set; }
    }

    public class ReviewModel
    {
        public int Id { get; set; }
        public string UserShowed { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class ResumeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DownloadLink { get; set; }
        public string Category { get; set; }
        public string UploadedDocumentsPathsJson { get; set; } = "";
        private List<string> _uploadedDocumentsPaths = new();

        public List<string> UploadedDocumentsPaths
        {
            get => _uploadedDocumentsPaths;
            set => _uploadedDocumentsPaths = value ?? new List<string>();
        }

        public ResumeModel()
        {
            UploadedDocumentsPaths = new List<string>();
        }

        public ResumeModel(List<string> uploadedDocumentsPaths)
        {
            UploadedDocumentsPaths = uploadedDocumentsPaths;
        }
    }

}
